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
		public static string PanelNotificationDetailMarkup { get; set; } = string.Empty;
		public static string PageNotificationDetailMarkup { get; set; } = string.Empty;

        #region Gets
        [JSInvokable]
        public static Course GetCourseByGuid(string guid)
        {
            try
            {
                Course course = new CourseService(new ApplicationDbContext(new())).GetCourseByGuid(guid);
                course.Author = new();
                course.Author = new AccountService(new ApplicationDbContext(new())).GetCreator(course.AuthorId);
                course.Author.Account = new();
                course.Author.Account = new AccountService(new ApplicationDbContext(new())).GetAccount(course.Author.AccountId);
                course.Author.Account.User = new();
                course.Author.Account.User = new UserService(new ApplicationDbContext(new())).GetUser(course.Author.Account.UserId);/*
                Course course = new CourseService(new ApplicationDbContext(new())).GetCourseByGuid(guid);
                course.Author = new();
                course.Author = new AccountService(new ApplicationDbContext(new())).GetCreator(course.AuthorId);
                course.Author.Account = new();
                course.Author.Account = new AccountService(new ApplicationDbContext(new())).GetAccount(course.Author.AccountId);
                course.Author.Account.User = new();
                course.Author.Account.User = new UserService(new ApplicationDbContext(new())).GetUser(course.Author.Account.UserId);*/
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
                Course course = new CourseService(new ApplicationDbContext(new())).GetCourse(courseId);
                course.Author = new();
                course.Author = new AccountService(new ApplicationDbContext(new())).GetCreator(course.AuthorId);
                course.Author.Account = new();
                course.Author.Account = new AccountService(new ApplicationDbContext(new())).GetAccount(course.Author.AccountId);
                course.Author.Account.User = new();
                course.Author.Account.User = new UserService(new ApplicationDbContext(new())).GetUser(course.Author.Account.UserId);
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
			ObservableCollection<CourseIndex> Indices = new();

			var chapterIds = new CourseService(new(new())).GetCourseChapterIdsAndNumber(courseId).OrderBy(x => x.Number);

			int count = 0;
			foreach (var cId in chapterIds)
			{
				var lessonIds = new CourseService(new(new())).GetCourseLessonIdsAndNumber(cId.ObjectId).OrderBy(x => x.Number);
				foreach (var lId in lessonIds)
				{
					var contentIds = new CourseService(new(new())).GetCourseContentIdsAndNumber(lId.ObjectId).OrderBy(x => x.Number);
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

						if (new QuizService(new ApplicationDbContext(new())).GetChapterQuizzes(cId.ObjectId).Count > 0) index.HasQuiz = true;

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
			var DataIndex = new CourseService(new(new())).GetCourseDataIndex(courseId);
			var CourseDataIndex = JsonConvert.DeserializeObject<ObservableCollection<CourseIndex>>(DataIndex.IndexData);
			ObservableCollection<CourseIndex> Indices = new();

			//var chapterIds = new CourseService(new()).GetCourseChapterIdsAndNumber(courseId);

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
					//var list1 = existingIndex.Where(x => x.)
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
				if (new QuizService(new ApplicationDbContext(new())).GetChapterQuizzes(newIndex[i].ChapterId).Count > 0)
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

			//var list4 = List;
			//list4.GroupBy(x => x.ChapterGuid).ToList().ForEach(x => x.GroupBy(x => x.LessonNumber).Last().ToList().ForEach(x => x.IsLastLesson = true));//.ToList().ForEach(x => x.IsLastLesson = true));
			


			//list4.ForEach(x => x.Last().IsLastContent = true);

			File.WriteAllText($@"C:\Users\Rodern\Desktop\Dump2.json", JsonConvert.SerializeObject(newIndex, Formatting.Indented));

			return newIndex;
		}

        [JSInvokable]
        public static ObservableCollection<Course> GetCourses()
        {
            var courses =  new CourseService(new ApplicationDbContext(new())).GetCourses();
            for (int i = 0; i < courses.Count; i++)
            {
                courses[i].Author = new();
                courses[i].Author = new AccountService(new ApplicationDbContext(new())).GetCreator(courses[i].AuthorId);
                courses[i].Author.Account = new();
                courses[i].Author.Account = new AccountService(new ApplicationDbContext(new())).GetAccount(courses[i].Author.AccountId);
                courses[i].Author.Account.User = new();
                courses[i].Author.Account.User = new UserService(new ApplicationDbContext(new())).GetUser(courses[i].Author.Account.UserId);
            }
            return courses;
        }
        [JSInvokable]
        public static ObservableCollection<CourseChapter> GetCourseChapters(int courseId)
        {
            ObservableCollection<CourseChapter> chapters = new CourseService(new ApplicationDbContext(new())).GetCourseChapters(courseId);
            for(int i = 0; i < chapters.Count; i++)
            {
                chapters[i].Course = new();
                chapters[i].Course = new CourseService(new ApplicationDbContext(new())).GetCourse(chapters[i].CourseId);
                //chapters[i].CourseLessons = new();
                chapters[i].Lessons = new CourseService(new ApplicationDbContext(new())).GetCourseLessons(chapters[i].CourseId);
                chapters[i].Author = new();
                chapters[i].Author = new AccountService(new ApplicationDbContext(new())).GetCreator(chapters[i].AuthorId);
            }
            return chapters;
        }
        [JSInvokable]
        public static ObservableCollection<CourseLesson> GetCourseLessons(int chapterId)
        {
            ObservableCollection<CourseLesson> lessons = new CourseService(new ApplicationDbContext(new())).GetCourseLessons(chapterId);
            for(int i = 0; i < lessons.Count; i++)
            {
                lessons[i].Chapter = new();
                lessons[i].Chapter = new CourseService(new ApplicationDbContext(new())).GetCourseChapter(lessons[i].ChapterId);
                //lessons[i].CourseContents = GetCourseContents(lessons[i].ChapterId);
                lessons[i].Author = new();
                lessons[i].Author = new AccountService(new ApplicationDbContext(new())).GetCreator(lessons[i].AuthorId);
            }
            return lessons;
        }
        [JSInvokable]
        public static ObservableCollection<CourseContent> GetCourseContents(int enrollmentId)
        {
            ObservableCollection<CourseContent> contents = new CourseService(new ApplicationDbContext(new())).GetCourseContents(enrollmentId);
            for(int i = 0; i < contents.Count; i++)
            {
                contents[i].Lesson = new();
                contents[i].Lesson = new CourseService(new ApplicationDbContext(new())).GetCourseLesson(contents[i].LessonId);
                contents[i].Author = new();
                contents[i].Author = new AccountService(new ApplicationDbContext(new())).GetCreator(contents[i].AuthorId);
            }
            return contents;
        }
        [JSInvokable]
        public static ObservableCollection<CourseData> GetCourseData(int enrollmentId)
        {
            ObservableCollection<CourseData> data = new CourseService(new ApplicationDbContext(new())).GetCourseData(enrollmentId);
            for(int i = 0; i < data.Count; i++)
            {
                data[i].Enrollment = new();
                data[i].Enrollment = new EnrollmentService(new ApplicationDbContext(new())).GetEnrollment(data[i].EnrollmentId);
            }
            return data;
        }
        #endregion
        #region Creates
        public static ResponseModel CreateEnrollment(Enrollment enrollment)
        {
            return new EnrollmentService(new ApplicationDbContext(new())).CreateEnrollment(enrollment);
        }
        public static ResponseModel UpdateEnrollment(Enrollment enrollment)
        {
            return new EnrollmentService(new ApplicationDbContext(new())).UpdateEnrollment(enrollment);
        }
        public static ResponseModel DeleteEnrollment(int enrollmentId)
        {
            return new EnrollmentService(new ApplicationDbContext(new())).DeleteEnrollment(enrollmentId);
        }
        public static ObservableCollection<Enrollment> GetEnrollments(int enrollmentId, long userId)
        {
            return new EnrollmentService(new ApplicationDbContext(new())).GetUserEnrollments(enrollmentId, userId);
        }
        public static ObservableCollection<Enrollment> GetEnrollments()
        {
            return new EnrollmentService(new ApplicationDbContext(new())).GetEnrollments();
        }
        #endregion
        #region userCourse
        public static ResponseModel CreateCourseDatum(CourseData datum)
        {
            return new CourseService(new ApplicationDbContext(new())).CreateCourseDatum(datum);
        }
        public static ResponseModel UpdateCourseData(CourseData datum)
        {
            return new CourseService(new ApplicationDbContext(new())).UpdateCourseDatum(datum);
        }
        public static ResponseModel DeleteCourseDatum(int dataId)
        {
            return new CourseService(new ApplicationDbContext(new())).DeleteCourseDatum(dataId);
        }
        #endregion
    }
}
