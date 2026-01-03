using BusinessLogic;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Learning;
using SkillIT_Models.Entities.Analytics;
using SkillIT_Models.Data;
using SkillIT_Models.Models;
using System.Collections.ObjectModel;
using SkillIT_Models.Entities.Courses;

namespace SkillIT_UI.Models
{
    public static class CourseStaticHelper
    {
		private static IServiceProvider? _serviceProvider;
		
		public static void Initialize(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		private static ApplicationDbContext GetDbContext()
		{
			if (_serviceProvider == null)
				throw new InvalidOperationException("CourseStaticHelper not initialized. Call Initialize() first.");
			
			var scope = _serviceProvider.CreateScope();
			return scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
		}

		public static string PanelNotificationDetailMarkup { get; set; } = string.Empty;
		public static string PageNotificationDetailMarkup { get; set; } = string.Empty;

        #region Gets
        [JSInvokable]
        public static Course GetCourseByGuid(string guid)
        {
            try
            {
                using var db = GetDbContext();
                Course course = new CourseService(db).GetCourseByGuid(guid);
                return course;
            }
            catch (Exception)
            {
                return new();
            }
        }
        [JSInvokable]
        public static Course GetCourse(long courseId)
        {
            try
            {
                using var db = GetDbContext();
                Course course = new CourseService(db).GetCourse(courseId);
                return course;
            }
            catch (Exception)
            {
                return new();
            }
        }

        [JSInvokable]
        public static ObservableCollection<CourseIndex> IndexCourse(long courseId)
        {
			using var db = GetDbContext();
			ObservableCollection<CourseIndex> Indices = new();

			var chapterIds = new CourseService(db).GetCourseChapterIdsAndNumber(courseId).OrderBy(x => x.Number);

			int count = 0;
			foreach (var cId in chapterIds)
			{
				var lessonIds = new CourseService(db).GetCourseLessonIdsAndNumber(cId.ObjectId).OrderBy(x => x.Number);
				foreach (var lId in lessonIds)
				{
					var contentIds = new CourseService(db).GetCourseContentIdsAndNumber(lId.ObjectId).OrderBy(x => x.Number);
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
						
						if (chapterIds.LastOrDefault().Guid == cId.Guid)
						{
							index.IsLastChapter = true;
						}
						if (lessonIds.LastOrDefault().Guid == lId.Guid)
						{
							index.IsLastLesson = true;
						}
						if (contentIds.LastOrDefault().Guid == ccId.Guid)
						{
							index.IsLastContent = true;
							
						}

						if (new QuizService(db).GetChapterQuizzes(cId.ObjectId).Count > 0) index.HasQuiz = true;

						Indices.Add(index);
					}
				}
			}

			File.WriteAllText($@"C:\Users\Rodern\Desktop\Dump1.json", JsonConvert.SerializeObject(Indices, Formatting.Indented));

			return Indices;
        }

		[JSInvokable]
		public static ObservableCollection<CourseIndex> MergeIndex(int courseId, ObservableCollection<CourseIndex> existingIndex)
		{
			using var db = GetDbContext();
			var DataIndex = new CourseService(db).GetCourseDataIndex(courseId);
			var CourseDataIndex = JsonConvert.DeserializeObject<ObservableCollection<CourseIndex>>(DataIndex.IndexData);
			ObservableCollection<CourseIndex> Indices = new();

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
					existingIndex.FirstOrDefault(ei => 
					ei.ChapterId == i.ChapterId 
					&& ei.LessonId == i.LessonId 
					&& ei.ContentId == i.ContentId 
					
					&& ei.ChapterNumber == i.ChapterNumber 
					&& ei.LessonNumber == i.LessonNumber 
					&& ei.ContentNumber == i.ContentNumber

					&& ei.ChapterGuid == i.ChapterGuid
					&& ei.LessonGuid == i.LessonGuid
					&& ei.ContentGuid == i.ContentGuid
					).IsDeleted = true;
				}
			}

			newIndex = new(existingIndex.OrderBy(x => x.ChapterNumber).ThenBy(x => x.LessonNumber).ThenBy(x => x.ContentNumber));

			for (int i = 0; i < newIndex.Count; i++)
			{
				newIndex[i].CourseIndexId = i + 1;
			}


			for (int i = 0; i < newIndex.ToList().Count(); i++)
			{
				if (new QuizService(db).GetChapterQuizzes(newIndex[i].ChapterId).Count > 0)
				{
					newIndex[i].HasQuiz = true;
				}
				newIndex[i].IsLastChapter = false;
				newIndex[i].IsLastLesson = false;
				newIndex[i].IsLastContent = false;
			}
			var List = newIndex.ToList();
			List.Where(x => x.ChapterNumber >= List.Max(x => x.ChapterNumber)).ToList().ForEach(x => x.IsLastChapter = true);

			List.GroupBy(x => x.ChapterGuid).ToList().ForEach(x => x.GroupBy(x => x.LessonNumber).Last().ToList().ForEach(x => x.IsLastLesson = true));

			List.GroupBy(x => x.LessonGuid).ToList().ForEach(x => x.Last().IsLastContent = true);

			newIndex = new(List);

			File.WriteAllText($@"C:\Users\Rodern\Desktop\Dump2.json", JsonConvert.SerializeObject(newIndex, Formatting.Indented));

			return newIndex;
		}

        [JSInvokable]
        public static ObservableCollection<Course> GetCourses()
        {
            using var db = GetDbContext();
            var courses = new CourseService(db).GetCourses();
            for (int i = 0; i < courses.Count; i++)
            {
                courses[i].Author = new();
                courses[i].Author = new AccountService(db).GetCreator(courses[i].AuthorId);
                courses[i].Author.Account = new();
                courses[i].Author.Account = new AccountService(db).GetAccount(courses[i].Author.AccountId);
                courses[i].Author.Account.User = new();
                courses[i].Author.Account.User = new UserService(db).GetUser(courses[i].Author.Account.UserId);
            }
            return courses;
        }
        [JSInvokable]
        public static ObservableCollection<CourseChapter> GetCourseChapters(int courseId)
        {
            using var db = GetDbContext();
            ObservableCollection<CourseChapter> chapters = new CourseService(db).GetCourseChapters(courseId);
            for(int i = 0; i < chapters.Count; i++)
            {
                chapters[i].Course = new();
                chapters[i].Course = new CourseService(db).GetCourse(chapters[i].CourseId);
                chapters[i].Lessons = new CourseService(db).GetCourseLessons(chapters[i].CourseId);
                chapters[i].Author = new();
                chapters[i].Author = new AccountService(db).GetCreator(chapters[i].AuthorId);
            }
            return chapters;
        }
        [JSInvokable]
        public static ObservableCollection<CourseLesson> GetCourseLessons(int chapterId)
        {
            using var db = GetDbContext();
            ObservableCollection<CourseLesson> lessons = new CourseService(db).GetCourseLessons(chapterId);
            for(int i = 0; i < lessons.Count; i++)
            {
                lessons[i].Chapter = new();
                lessons[i].Chapter = new CourseService(db).GetCourseChapter(lessons[i].ChapterId);
                lessons[i].Author = new();
                lessons[i].Author = new AccountService(db).GetCreator(lessons[i].AuthorId);
            }
            return lessons;
        }
        [JSInvokable]
        public static ObservableCollection<CourseContent> GetCourseContents(int enrollmentId)
        {
            using var db = GetDbContext();
            ObservableCollection<CourseContent> contents = new CourseService(db).GetCourseContents(enrollmentId);
            for(int i = 0; i < contents.Count; i++)
            {
                contents[i].Lesson = new();
                contents[i].Lesson = new CourseService(db).GetCourseLesson(contents[i].LessonId);
                contents[i].Author = new();
                contents[i].Author = new AccountService(db).GetCreator(contents[i].AuthorId);
            }
            return contents;
        }
        [JSInvokable]
        public static ObservableCollection<CourseData> GetCourseData(int enrollmentId)
        {
            using var db = GetDbContext();
            ObservableCollection<CourseData> data = new CourseService(db).GetCourseData(enrollmentId);
            for(int i = 0; i < data.Count; i++)
            {
                data[i].Enrollment = new();
                data[i].Enrollment = new EnrollmentService(db).GetEnrollment(data[i].EnrollmentId);
            }
            return data;
        }
        #endregion
        #region Creates
        public static ResponseModel CreateEnrollment(Enrollment enrollment)
        {
            using var db = GetDbContext();
            return new EnrollmentService(db).CreateEnrollment(enrollment);
        }
        public static ResponseModel UpdateEnrollment(Enrollment enrollment)
        {
            using var db = GetDbContext();
            return new EnrollmentService(db).UpdateEnrollment(enrollment);
        }
        public static ResponseModel DeleteEnrollment(int enrollmentId)
        {
            using var db = GetDbContext();
            return new EnrollmentService(db).DeleteEnrollment(enrollmentId);
        }
        public static ObservableCollection<Enrollment> GetEnrollments(int enrollmentId, long userId)
        {
            using var db = GetDbContext();
            return new EnrollmentService(db).GetUserEnrollments(enrollmentId, userId);
        }
        public static ObservableCollection<Enrollment> GetEnrollments()
        {
            using var db = GetDbContext();
            return new EnrollmentService(db).GetEnrollments();
        }
        #endregion
        #region userCourse
        public static ResponseModel CreateCourseDatum(CourseData datum)
        {
            using var db = GetDbContext();
            return new CourseService(db).CreateCourseDatum(datum);
        }
        public static ResponseModel UpdateCourseData(CourseData datum)
        {
            using var db = GetDbContext();
            return new CourseService(db).UpdateCourseDatum(datum);
        }
        public static ResponseModel DeleteCourseDatum(int dataId)
        {
            using var db = GetDbContext();
            return new CourseService(db).DeleteCourseDatum(dataId);
        }
        #endregion
    }
}
