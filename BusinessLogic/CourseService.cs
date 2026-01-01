using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillIT_Models;
using SkillIT_Models.Constants;
using SkillIT_Models.CRUD;
using SkillIT_Models.Data;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessLogic
{
    /// <summary>
    /// Service for managing courses, chapters, lessons, and content
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly ILogger<CourseService> _logger;

        public CourseService(ApplicationDbContext dbContext, ILogger<CourseService> logger = null)
        {
            _databaseContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger;
        }

        #region Course

        /// <summary>
        /// Creates a new course
        /// </summary>
        public ResponseModel CreateCourse(Course course)
        {
            try
            {
                _logger?.LogInformation("Creating new course: {CourseName}", course?.Name);
                return Crud.Create(course.CourseId, course, _databaseContext);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error creating course");
                return new ResponseModel(false, $"{AppConstants.Messages.Failed}: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a course by ID
        /// </summary>
        public ResponseModel DeleteCourse(int courseId)
        {
            try
            {
                _logger?.LogInformation("Deleting course with ID: {CourseId}", courseId);
                return Crud.Delete<Course>(courseId, _databaseContext);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error deleting course {CourseId}", courseId);
                return new ResponseModel(false, $"{AppConstants.Messages.Failed}: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing course
        /// </summary>
        public ResponseModel UpdateCourse(Course course)
        {
            try
            {
                _logger?.LogInformation("Updating course with ID: {CourseId}", course?.CourseId);
                return Crud.Update(course.CourseId, course, _databaseContext);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error updating course {CourseId}", course?.CourseId);
                return new ResponseModel(false, $"{AppConstants.Messages.Failed}: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a course by ID
        /// </summary>
        public Course GetCourse(int courseId)
        {
            try
            {
                return Crud.Read<Course>(courseId, _databaseContext);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error retrieving course {CourseId}", courseId);
                return null;
            }
        }

        /// <summary>
        /// Gets a course by GUID
        /// </summary>
        public Course GetCourseByGuid(string guid)
        {
            try
            {
                return _databaseContext.Courses
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Guid == guid);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error retrieving course by GUID {Guid}", guid);
                return null;
            }
        }

        /// <summary>
        /// Gets a course chapter by GUID
        /// </summary>
        public CourseChapter GetCourseChapterByGuid(string guid)
        {
            try
            {
                return _databaseContext.CourseChapters
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Guid == guid);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error retrieving chapter by GUID {Guid}", guid);
                return null;
            }
        }

        /// <summary>
        /// Gets a course lesson by GUID
        /// </summary>
        public CourseLesson GetCourseLessonByGuid(string guid)
        {
            try
            {
                return _databaseContext.CourseLessons
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Guid == guid);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error retrieving lesson by GUID {Guid}", guid);
                return null;
            }
        }

        /// <summary>
        /// Gets course content by GUID
        /// </summary>
        public CourseContent GetCourseContentByGuid(string guid)
        {
            try
            {
                return _databaseContext.CourseContents
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Guid == guid);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error retrieving content by GUID {Guid}", guid);
                return null;
            }
        }

        /// <summary>
        /// Gets all courses
        /// </summary>
        public ObservableCollection<Course> GetCourses()
        {
            try
            {
                var courses = _databaseContext.Courses
                    .AsNoTracking()
                    .ToList();
                return new ObservableCollection<Course>(courses);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error retrieving all courses");
                return new ObservableCollection<Course>();
            }
        }
         
        /// <summary>
        /// Indexes a course for navigation
        /// </summary>
        public ObservableCollection<CourseIndex> IndexCourse(int courseId)
        {
			ObservableCollection<CourseIndex> Indices = new();
			ObservableCollection<int> chapterIds = new CourseService(new()).GetCourseChapterIds(courseId);

			int count = 0;
			foreach (int cId in chapterIds)
			{
				var lessonIds = new CourseService(new()).GetCourseLessonIds(cId);
				foreach (int lId in lessonIds)
				{
					var contentIds = new CourseService(new()).GetCourseContentIds(lId);
					foreach (int ccId in contentIds)
					{
						count++;
						Indices.Add(new()
						{
							CourseIndexId = count,
							CourseId = courseId,
							ChapterId = cId,
							LessonId = lId,
							ContentId = ccId
						});
					}
				}
			}
			return Indices;
		}

		#endregion

		#region CourseChapter
		public ResponseModel CreateCourseChapter(CourseChapter courseChapter)
        {
            return Crud.Create(courseChapter.ChapterId, courseChapter, DatabaseContext);
        }

        public ResponseModel DeleteCourseChapter(int chapterId)
        {
            return Crud.Delete<CourseChapter>(chapterId, DatabaseContext);
        }

        public ResponseModel UpdateCourse(CourseChapter courseChapter)
        {
            return Crud.Update(courseChapter.ChapterId, courseChapter, DatabaseContext);
        }

        public CourseChapter GetCourseChapter(int chapterId)
        {
            return Crud.Read<CourseChapter>(chapterId, DatabaseContext);
        }

        public ObservableCollection<CourseChapter> GetCourseChapters()
        {
            ObservableCollection<CourseChapter> chapters = new(_databaseContext.CourseChapters.ToList());
            
            return AddAuthors<CourseChapter>(chapters);
        }

        public ObservableCollection<CourseChapter> GetCourseChapters(int courseId)
        {
            var chapters = new ObservableCollection<CourseChapter>(_databaseContext.CourseChapters.Where(c => c.CourseId == courseId).ToList());
            return chapters;
        }

        public ObservableCollection<CourseChapter> GetCourseChapters(int chapterId, int courseId)
        {
            var chapters = new ObservableCollection<CourseChapter>(_databaseContext.CourseChapters.Where(c => c.ChapterId == chapterId && c.CourseId == courseId).ToList());
            return chapters;
        }
        #endregion

        #region CourseLesson
        public ResponseModel CreateCourseLesson(CourseLesson courseLesson)
        {
            return Crud.Create(courseLesson.LessonId, courseLesson, DatabaseContext);
        }

        public ResponseModel DeleteCourseLesson(int lessonId)
        {
            return Crud.Delete<CourseLesson>(lessonId, DatabaseContext);
        }

        public ResponseModel UpdateCourseLesson(CourseLesson courseLesson)
        {
            return Crud.Update(courseLesson.LessonId, courseLesson, DatabaseContext);
        }

        public CourseLesson GetCourseLesson(int lessonId)
        {
            return Crud.Read<CourseLesson>(lessonId, DatabaseContext);
        }

        public ObservableCollection<CourseLesson> GetCourseLessons()
        {
            var lessons = new ObservableCollection<CourseLesson>(_databaseContext.CourseLessons.ToList());
            return lessons;
        }

        public ObservableCollection<CourseLesson> GetCourseLessons(int chapterId)
        {
            var lessons = new ObservableCollection<CourseLesson>(_databaseContext.CourseLessons.Where(l => l.ChapterId == chapterId).ToList());
            return lessons;
        }
        #endregion
        ObservableCollection<T> AddAuthors<T>(dynamic list) where T: class
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Author = new Creator();
                list[i].Author = DatabaseContext.Creators.Find(list[i].AuthorId);
                //list[i].Course = new();
                //list[i].Chapter = DatabaseContext.CourseChapters.Where(a => a.ChapterId == chapters[i].CourseId).FirstOrDefault();
            }
            return list;
        }

        #region CourseContent
        public ResponseModel CreateCourseContent(CourseContent content)
        {
            return Crud.Create(content.ContentId, content, DatabaseContext);
        }

        public ResponseModel DeleteCourseContent(int contentId)
        {
            return Crud.Delete<CourseContent>(contentId, DatabaseContext);
        }

        public ResponseModel UpdateCourseContent(CourseContent content)
        {
            return Crud.Update(content.ContentId, content, DatabaseContext);
        }

        public CourseContent GetCourseContent(int contentId)
        {
            return Crud.Read<CourseContent>(contentId, DatabaseContext);
        }

        public ObservableCollection<CourseContent> GetCourseContents()
        {
            return new(_databaseContext.CourseContents.ToList());
        }

        public SubContent GetContentFeilds(int contentId)
        {
            return _databaseContext.CourseContents.Select(x => new SubContent
            {
                ContentId = x.ContentId,
                LessonId = x.LessonId,
                Title = x.Title,
                ContentNumber = x.ContentNumber,
                DateCreated = x.DateCreated,
            }).FirstOrDefault(x => x.ContentId == contentId);
        }

        public ObservableCollection<SubContent> GetContentFeildsByLessonId(int lessonId)
        {
            return new(_databaseContext.CourseContents.Select(x => new SubContent
            {
                ContentId = x.ContentId,
                LessonId = x.LessonId,
                Title = x.Title,
                ContentNumber = x.ContentNumber,
                DateCreated = x.DateCreated,
            }).Where(x => x.ContentId == lessonId));
        }

        public ObservableCollection<CourseContent> GetCourseContents(int lessonId)
        {
            return new(_databaseContext.CourseContents.Where(cc => cc.LessonId == lessonId).ToList());
        }
        #endregion

        #region CourseData
        public ResponseModel CreateCourseDatum(CourseDatum courseData)
        {
            return Crud.Create<CourseDatum>(courseData.DataId, courseData, DatabaseContext);
        }

        public ResponseModel DeleteCourseDatum(int dataId)
        {
            return Crud.Delete<CourseDatum>(dataId, DatabaseContext);
        }

        public ResponseModel UpdateCourseDatum(CourseDatum courseData)
        {
            return Crud.Update(courseData.DataId, courseData, DatabaseContext);
        }

        public CourseDatum GetCourseDatum(int dataId)
        {
            return Crud.Read<CourseDatum>(dataId, DatabaseContext);
        }

        public ObservableCollection<CourseDatum> GetCourseData()
        {
            return new(_databaseContext.CourseData.ToList());
        }

        public ObservableCollection<CourseDatum> GetCourseData(int enrollmentId)
        {
            return new(_databaseContext.CourseData.Where(cd => cd.EnrollmentId == enrollmentId).ToList());
        }

        public CourseDatum GetCourseDatumByEnrollmentId(int enrollmentId)
        {
            return _databaseContext.CourseData.FirstOrDefault(cd => cd.EnrollmentId == enrollmentId);
        }

		#endregion

		#region Selects


		public ObservableCollection<int> GetCourseIds()
		{
			return new ObservableCollection<int>(_databaseContext.CourseChapters.Select(x => x.ChapterId).ToList());
		}

		public ObservableCollection<int> GetCourseChapterIds(int courseId)
		{
			return new ObservableCollection<int>(_databaseContext.CourseChapters.OrderBy(x => x.ChapterNumber).Where(c => c.CourseId == courseId).Select(x => x.ChapterId).ToList());
		}

		public ObservableCollection<int> GetCourseLessonIds(int chapterId)
		{
			return new ObservableCollection<int>(_databaseContext.CourseLessons.OrderBy(x => x.LessonNumber).Where(c => c.ChapterId == chapterId).Select(x => x.LessonId).ToList());
		}

		public ObservableCollection<int> GetCourseContentIds(int lessonId)
		{
			return new ObservableCollection<int>(_databaseContext.CourseContents.OrderBy(x => x.ContentNumber).Where(c => c.LessonId == lessonId).Select(x => x.ContentId).ToList());
		}

		//public ObservableCollection<int, int> GetCourseIds()
		//{
		//	return new(DatabaseContext.CourseChapters.Select(x => x.ChapterId).ToList());
		//}

		public ObservableCollection<MiniINT> GetCourseChapterIdsAndNumber(int courseId)
		{
			return new(_databaseContext.CourseChapters.OrderBy(x => x.ChapterNumber).Where(c => c.CourseId == courseId).Select(x => new MiniINT() { ObjectId = x.ChapterId, Number = x.ChapterNumber, Guid = x.Guid }).ToList());
		}

		public ObservableCollection<MiniINT> GetCourseLessonIdsAndNumber(int chapterId)
		{
			return new(_databaseContext.CourseLessons.OrderBy(x => x.LessonNumber).Where(c => c.ChapterId == chapterId).Select(x => new MiniINT() { ObjectId = x.LessonId, Number = x.LessonNumber, Guid = x.Guid }).ToList());
		}

		public ObservableCollection<MiniINT> GetCourseContentIdsAndNumber(int lessonId)
		{
			return new (_databaseContext.CourseContents.OrderBy(x => x.ContentNumber).Where(c => c.LessonId == lessonId).Select(x => new MiniINT() { ObjectId = x.ContentId, Number = x.ContentNumber, Guid = x.Guid } ).ToList());
		}
		#endregion

		#region Index_data
        public DataIndex GetDataIndex(int indexId)
        {
            return Crud.Read<DataIndex>(indexId, DatabaseContext);
		}
		public DataIndex GetDataIndexByCourseId(int courseId)
		{
			return _databaseContext.DataIndices.FirstOrDefault(d => d.CourseId == courseId);
		}
		public ObservableCollection<DataIndex> GetDataIndices()
        {
            return new(_databaseContext.DataIndices);
        }
        public ObservableCollection<DataIndex> GetDataIndices(int courseId)
        {
            return new(_databaseContext.DataIndices.Where(i => i.CourseId == courseId));
        }
        public DataIndex GetCourseDataIndex(int courseId)
        {
            return _databaseContext.DataIndices.FirstOrDefault(i => i.CourseId == courseId);
        }
		#endregion
	}
}
