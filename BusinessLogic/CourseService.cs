using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillIT_Models;
using SkillIT_Models.Constants;
using SkillIT_Models.CRUD;
using SkillIT_Models.Data;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Courses;
using SkillIT_Models.Entities.Learning;
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

        public CourseService(ApplicationDbContext dbContext, ILogger<CourseService>? logger = null)
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
                return Crud.Create(course.Id, course, _databaseContext);
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
        public ResponseModel DeleteCourse(long courseId)
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
                _logger?.LogInformation("Updating course with ID: {CourseId}", course?.Id);
                return Crud.Update(course.Id, course, _databaseContext);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error updating course {CourseId}", course?.Id);
                return new ResponseModel(false, $"{AppConstants.Messages.Failed}: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a course by ID
        /// </summary>
        public Course? GetCourse(long courseId)
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
        public Course? GetCourseByGuid(string guid)
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
        public CourseChapter? GetCourseChapterByGuid(string guid)
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
        public CourseLesson? GetCourseLessonByGuid(string guid)
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
        public CourseContent? GetCourseContentByGuid(string guid)
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
        public ObservableCollection<CourseIndex> IndexCourse(long courseId)
        {
            ObservableCollection<CourseIndex> Indices = new();
            ObservableCollection<long> chapterIds = GetCourseChapterIds(courseId);

            long count = 0;
            foreach (long cId in chapterIds)
            {
                var lessonIds = GetCourseLessonIds(cId);
                foreach (long lId in lessonIds)
                {
                    var contentIds = GetCourseContentIds(lId);
                    foreach (long ccId in contentIds)
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
            return Crud.Create(courseChapter.Id, courseChapter, _databaseContext);
        }

        public ResponseModel DeleteCourseChapter(long chapterId)
        {
            return Crud.Delete<CourseChapter>(chapterId, _databaseContext);
        }

        public ResponseModel UpdateCourse(CourseChapter courseChapter)
        {
            return Crud.Update(courseChapter.Id, courseChapter, _databaseContext);
        }

        public CourseChapter? GetCourseChapter(long chapterId)
        {
            return Crud.Read<CourseChapter>(chapterId, _databaseContext);
        }

        public ObservableCollection<CourseChapter> GetCourseChapters()
        {
            ObservableCollection<CourseChapter> chapters = new(_databaseContext.CourseChapters.ToList());
            
            return AddAuthors<CourseChapter>(chapters);
        }

        public ObservableCollection<CourseChapter> GetCourseChapters(long courseId)
        {
            var chapters = new ObservableCollection<CourseChapter>(_databaseContext.CourseChapters.Where(c => c.CourseId == courseId).ToList());
            return chapters;
        }

        public ObservableCollection<CourseChapter> GetCourseChapters(long chapterId, long courseId)
        {
            var chapters = new ObservableCollection<CourseChapter>(_databaseContext.CourseChapters.Where(c => c.Id == chapterId && c.CourseId == courseId).ToList());
            return chapters;
        }
        #endregion

        #region CourseLesson
        public ResponseModel CreateCourseLesson(CourseLesson courseLesson)
        {
            return Crud.Create(courseLesson.Id, courseLesson, _databaseContext);
        }

        public ResponseModel DeleteCourseLesson(long lessonId)
        {
            return Crud.Delete<CourseLesson>(lessonId, _databaseContext);
        }

        public ResponseModel UpdateCourseLesson(CourseLesson courseLesson)
        {
            return Crud.Update(courseLesson.Id, courseLesson, _databaseContext);
        }

        public CourseLesson? GetCourseLesson(long lessonId)
        {
            return Crud.Read<CourseLesson>(lessonId, _databaseContext);
        }

        public ObservableCollection<CourseLesson> GetCourseLessons()
        {
            var lessons = new ObservableCollection<CourseLesson>(_databaseContext.CourseLessons.ToList());
            return lessons;
        }

        public ObservableCollection<CourseLesson> GetCourseLessons(long chapterId)
        {
            var lessons = new ObservableCollection<CourseLesson>(_databaseContext.CourseLessons.Where(l => l.ChapterId == chapterId).ToList());
            return lessons;
        }
        #endregion
        ObservableCollection<T> AddAuthors<T>(dynamic list) where T: class
        {
            for (long i = 0; i < list.Count; i++)
            {
                list[i].Author = new Creator();
                list[i].Author = _databaseContext.Creators.Find(list[i].AuthorId);
                //list[i].Course = new();
                //list[i].Chapter = DatabaseContext.CourseChapters.Where(a => a.ChapterId == chapters[i].CourseId).FirstOrDefault();
            }
            return list;
        }

        #region CourseContent
        public ResponseModel CreateCourseContent(CourseContent content)
        {
            return Crud.Create(content.Id, content, _databaseContext);
        }

        public ResponseModel DeleteCourseContent(long contentId)
        {
            return Crud.Delete<CourseContent>(contentId, _databaseContext);
        }

        public ResponseModel UpdateCourseContent(CourseContent content)
        {
            return Crud.Update(content.Id, content, _databaseContext);
        }

        public CourseContent? GetCourseContent(long contentId)
        {
            return Crud.Read<CourseContent>(contentId, _databaseContext);
        }

        public ObservableCollection<CourseContent> GetCourseContents()
        {
            return new(_databaseContext.CourseContents.ToList());
        }

        public SubContent GetContentFeilds(long contentId)
        {
            return _databaseContext.CourseContents.Select(x => new SubContent
            {
                ContentId = (long)x.Id,
                LessonId = x.LessonId,
                Title = x.Title,
                ContentNumber = x.ContentNumber,
                DateCreated = x.DateCreated,
            }).FirstOrDefault(x => x.ContentId == contentId);
        }

        public ObservableCollection<SubContent> GetContentFeildsByLessonId(long lessonId)
        {
            return new(_databaseContext.CourseContents.Select(x => new SubContent
            {
                ContentId = (int)x.Id,
                LessonId = x.LessonId,
                Title = x.Title,
                ContentNumber = x.ContentNumber,
                DateCreated = x.DateCreated,
            }).Where(x => x.ContentId == lessonId));
        }

        public ObservableCollection<CourseContent> GetCourseContents(long lessonId)
        {
            return new(_databaseContext.CourseContents.Where(cc => cc.LessonId == lessonId).ToList());
        }
        #endregion

        #region CourseData
        public ResponseModel CreateCourseDatum(CourseData courseData)
        {
            return Crud.Create<CourseData>(courseData.Id, courseData, _databaseContext);
        }

        public ResponseModel DeleteCourseDatum(long dataId)
        {
            return Crud.Delete<CourseData>(dataId, _databaseContext);
        }

        public ResponseModel UpdateCourseDatum(CourseData courseData)
        {
            return Crud.Update(courseData.Id, courseData, _databaseContext);
        }

        public CourseData GetCourseDatum(long dataId)
        {
            return Crud.Read<CourseData>(dataId, _databaseContext);
        }

        public ObservableCollection<CourseData> GetCourseData()
        {
            return new(_databaseContext.CourseData.ToList());
        }

        public ObservableCollection<CourseData> GetCourseData(long enrollmentId)
        {
            return new(_databaseContext.CourseData.Where(cd => cd.EnrollmentId == enrollmentId).ToList());
        }

        public CourseData? GetCourseDatumByEnrollmentId(long enrollmentId)
        {
            return _databaseContext.CourseData.FirstOrDefault(cd => cd.EnrollmentId == enrollmentId);
        }

		#endregion

		#region Selects

        public User GetCourseAuthorDetails(long? authorId)
        {
            long? accountId = _databaseContext.Creators.FirstOrDefault(a => a.Id == authorId).AccountId;
            long? userId = _databaseContext.Accounts.FirstOrDefault(a => a.Id == accountId).UserId;
            return _databaseContext.Users.FirstOrDefault(u => u.Id == userId);
        }

		public ObservableCollection<long> GetCourseIds()
		{
			return new ObservableCollection<long>(_databaseContext.CourseChapters.Select(x => (long)x.Id).ToList());
		}

		public ObservableCollection<long> GetCourseChapterIds(long courseId)
		{
			return new ObservableCollection<long>(_databaseContext.CourseChapters.OrderBy(x => x.ChapterNumber).Where(c => c.CourseId == courseId).Select(x => (long)x.Id).ToList());
		}

		public ObservableCollection<long> GetCourseLessonIds(long chapterId)
		{
			return new ObservableCollection<long>(_databaseContext.CourseLessons.OrderBy(x => x.LessonNumber).Where(c => c.ChapterId == chapterId).Select(x => (long)x.Id).ToList());
		}

		public ObservableCollection<long> GetCourseContentIds(long lessonId)
		{
			return new ObservableCollection<long>(_databaseContext.CourseContents.OrderBy(x => x.ContentNumber).Where(c => c.LessonId == lessonId).Select(x => (long)x.Id).ToList());
		}

		//public ObservableCollection<int, int> GetCourseIds()
		//{
		//	return new(DatabaseContext.CourseChapters.Select(x => x.ChapterId).ToList());
		//}

		public ObservableCollection<MiniINT> GetCourseChapterIdsAndNumber(long courseId)
		{
			return new(_databaseContext.CourseChapters.OrderBy(x => x.ChapterNumber).Where(c => c.CourseId == courseId).Select(x => new MiniINT() { ObjectId = (int)x.Id, Number = x.ChapterNumber, Guid = x.Guid }).ToList());
		}

		public ObservableCollection<MiniINT> GetCourseLessonIdsAndNumber(long chapterId)
		{
			return new(_databaseContext.CourseLessons.OrderBy(x => x.LessonNumber).Where(c => c.ChapterId == chapterId).Select(x => new MiniINT() { ObjectId = (int)x.Id, Number = x.LessonNumber, Guid = x.Guid }).ToList());
		}

		public ObservableCollection<MiniINT> GetCourseContentIdsAndNumber(long lessonId)
		{
			return new (_databaseContext.CourseContents.OrderBy(x => x.ContentNumber).Where(c => c.LessonId == lessonId).Select(x => new MiniINT() { ObjectId = (int)x.Id, Number = x.ContentNumber, Guid = x.Guid } ).ToList());
		}
		#endregion

		#region Index_data
        public DataIndex? GetDataIndex(long indexId)
        {
            return Crud.Read<DataIndex>(indexId, _databaseContext);
		}
		public DataIndex? GetDataIndexByCourseId(long courseId)
		{
			return _databaseContext.DataIndexes.FirstOrDefault(d => d.CourseId == courseId);
		}
		public ObservableCollection<DataIndex> GetDataIndices()
        {
            return new(_databaseContext.DataIndexes);
        }
        public ObservableCollection<DataIndex> GetDataIndices(long courseId)
        {
            return new(_databaseContext.DataIndexes.Where(i => i.CourseId == courseId));
        }
        public DataIndex? GetCourseDataIndex(long courseId)
        {
            return _databaseContext.DataIndexes.FirstOrDefault(i => i.CourseId == courseId);
        }
		#endregion
	}
}
