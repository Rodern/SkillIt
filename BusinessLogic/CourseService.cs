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
        public ObservableCollection<Course> GetCoursesWithDetails()
        {
            try
            {
                var courses = _databaseContext.Courses
                    .Include(c => c.Author)
                        .ThenInclude(a => a.Account)
                            .ThenInclude(ac => ac.User)
                    .AsNoTracking()
                    .ToList();
                return new ObservableCollection<Course>(courses);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error retrieving all courses with details");
                return new ObservableCollection<Course>();
            }
        }
         
        public ObservableCollection<CourseIndex> IndexCourse(long courseId)
        {
			ObservableCollection<CourseIndex> Indices = new();
			var chapterIds = GetCourseChapterIdsAndNumber(courseId).OrderBy(x => x.Number).ToList();

			int count = 0;
			foreach (var cId in chapterIds)
			{
				var lessonIds = GetCourseLessonIdsAndNumber(cId.ObjectId).OrderBy(x => x.Number).ToList();
				foreach (var lId in lessonIds)
				{
					var contentIds = GetCourseContentIdsAndNumber(lId.ObjectId).OrderBy(x => x.Number).ToList();
					foreach (var ccId in contentIds)
					{
						count++;
						var index = new CourseIndex(count, courseId, cId.ObjectId, lId.ObjectId, ccId.ObjectId)
						{
							ChapterNumber = cId.Number,
							LessonNumber = lId.Number,
							ContentNumber = ccId.Number,
							ChapterGuid = cId.Guid,
							LessonGuid = lId.Guid,
							ContentGuid = ccId.Guid
						};

						if (count == 1)
						{
							index.IsUnlocked = true;
							index.DateUnlocked = DateTime.UtcNow;
						}
						
						if (chapterIds.LastOrDefault()?.Guid == cId.Guid)
						{
							index.IsLastChapter = true;
						}
						if (lessonIds.LastOrDefault()?.Guid == lId.Guid)
						{
							index.IsLastLesson = true;
						}
						if (contentIds.LastOrDefault()?.Guid == ccId.Guid)
						{
							index.IsLastContent = true;
						}

						if (_databaseContext.ChapterQuizzes.Any(q => q.ChapterId == cId.ObjectId)) 
                            index.HasQuiz = true;

						Indices.Add(index);
					}
				}
			}
			return Indices;
		}

        public ObservableCollection<CourseIndex> MergeIndex(long courseId, ObservableCollection<CourseIndex> existingIndex)
        {
			var DataIndex = GetCourseDataIndex(courseId);
            if (DataIndex == null || string.IsNullOrEmpty(DataIndex.IndexData))
                return existingIndex;
                
			var CourseDataIndex = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<CourseIndex>>(DataIndex.IndexData);
            if (CourseDataIndex == null) return existingIndex;

			ObservableCollection<CourseIndex> newIndex = new();
			foreach (var di in CourseDataIndex)
			{
				if (existingIndex.Count(ei => 
					ei.ChapterId == di.ChapterId 
					&& ei.LessonId == di.LessonId 
					&& ei.ContentId == di.ContentId 
					&& ei.ChapterNumber == di.ChapterNumber 
					&& ei.LessonNumber == di.LessonNumber 
					&& ei.ContentNumber == di.ContentNumber
					&& ei.ChapterGuid == di.ChapterGuid
					&& ei.LessonGuid == di.LessonGuid
					&& ei.ContentGuid == di.ContentGuid
				) < 1)
				{
					existingIndex.Add(di);
				}
			}

			foreach (var i in existingIndex)
			{
				if (CourseDataIndex.Count(ei => 
					ei.ChapterId == i.ChapterId 
					&& ei.LessonId == i.LessonId 
					&& ei.ContentId == i.ContentId 
					&& ei.ChapterNumber == i.ChapterNumber 
					&& ei.LessonNumber == i.LessonNumber 
					&& ei.ContentNumber == i.ContentNumber
					&& ei.ChapterGuid == i.ChapterGuid
					&& ei.LessonGuid == i.LessonGuid
					&& ei.ContentGuid == i.ContentGuid
				) < 1)
				{
					var toDelete = existingIndex.FirstOrDefault(ei => 
					ei.ChapterId == i.ChapterId 
					&& ei.LessonId == i.LessonId 
					&& ei.ContentId == i.ContentId 
					&& ei.ChapterNumber == i.ChapterNumber 
					&& ei.LessonNumber == i.LessonNumber 
					&& ei.ContentNumber == i.ContentNumber
					&& ei.ChapterGuid == i.ChapterGuid
					&& ei.LessonGuid == i.LessonGuid
					&& ei.ContentGuid == i.ContentGuid
					);
                    if (toDelete != null) toDelete.IsDeleted = true;
				}
			}

			newIndex = new(existingIndex.OrderBy(x => x.ChapterNumber).ThenBy(x => x.LessonNumber).ThenBy(x => x.ContentNumber));

			for (int i = 0; i < newIndex.Count; i++)
			{
				newIndex[i].CourseIndexId = i + 1;
			}

			for (int i = 0; i < newIndex.ToList().Count(); i++)
			{
				if (_databaseContext.ChapterQuizzes.Any(q => q.ChapterId == newIndex[i].ChapterId))
				{
					newIndex[i].HasQuiz = true;
				}
				newIndex[i].IsLastChapter = false;
				newIndex[i].IsLastLesson = false;
				newIndex[i].IsLastContent = false;
			}
			var List = newIndex.ToList();
            if (List.Any())
            {
			    List.Where(x => x.ChapterNumber >= List.Max(x => x.ChapterNumber)).ToList().ForEach(x => x.IsLastChapter = true);
			    List.GroupBy(x => x.ChapterGuid).ToList().ForEach(x => x.GroupBy(x => x.LessonNumber).Last().ToList().ForEach(x => x.IsLastLesson = true));
			    List.GroupBy(x => x.LessonGuid).ToList().ForEach(x => x.Last().IsLastContent = true);
            }
			newIndex = new(List);

			return newIndex;
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

        public ObservableCollection<CourseChapter> GetCourseChaptersWithDetails(long courseId)
        {
            var chapters = _databaseContext.CourseChapters
                .Include(c => c.Course)
                .Include(c => c.Lessons)
                .Include(c => c.Author)
                .Where(c => c.CourseId == courseId)
                .AsNoTracking()
                .ToList();
            return new ObservableCollection<CourseChapter>(chapters);
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

        public ObservableCollection<CourseLesson> GetCourseLessonsWithDetails(long chapterId)
        {
            var lessons = _databaseContext.CourseLessons
                .Include(l => l.Chapter)
                .Include(l => l.Author)
                .Where(l => l.ChapterId == chapterId)
                .AsNoTracking()
                .ToList();
            return new ObservableCollection<CourseLesson>(lessons);
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

        public ObservableCollection<CourseContent> GetCourseContentsWithDetails(long lessonId)
        {
            var contents = _databaseContext.CourseContents
                .Include(c => c.Lesson)
                .Include(c => c.Author)
                .Where(c => c.LessonId == lessonId)
                .AsNoTracking()
                .ToList();
            return new ObservableCollection<CourseContent>(contents);
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

        public ObservableCollection<CourseData> GetCourseDataWithDetails(long enrollmentId)
        {
            var data = _databaseContext.CourseData
                .Include(cd => cd.Enrollment)
                .Where(cd => cd.EnrollmentId == enrollmentId)
                .AsNoTracking()
                .ToList();
            return new ObservableCollection<CourseData>(data);
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
