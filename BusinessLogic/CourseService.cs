using BusinessLogic.Interfaces;
using Microsoft.JSInterop;
using SkillIT_Models;
using SkillIT_Models.CRUD;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System.Collections.ObjectModel;

namespace BusinessLogic
{
    public class CourseService : ICourseService
    {
        private readonly skill_it_dbContext DatabaseContext;
    
        private static readonly skill_it_dbContext StaticDatabaseContext;

        public CourseService(skill_it_dbContext dbContext)
        {
            this.DatabaseContext = dbContext;
        }

        #region Course
        public ResponseModel CreateCourse(Course course)
        {
            return Crud.Create(course.CourseId, course, DatabaseContext);
        }

        public ResponseModel DeleteCourse(int courseId)
        {
            return Crud.Delete<Course>(courseId, DatabaseContext);
        }

        public ResponseModel UpdateCourse(Course course)
        {
            return Crud.Update(course.CourseId, course, DatabaseContext);
        }

        public Course GetCourse(int courseId)
        {
            return Crud.Read<Course>(courseId, DatabaseContext);
        }

        public Course GetCourseByGuid(string guid)
        {
            return DatabaseContext.Courses.FirstOrDefault(c => c.Guid == guid);
        }

        public CourseChapter GetCourseChapterByGuid(string guid)
        {
            return DatabaseContext.CourseChapters.FirstOrDefault(c => c.Guid == guid);
        }

        public CourseLesson GetCourseLessonByGuid(string guid)
        {
            return DatabaseContext.CourseLessons.FirstOrDefault(c => c.Guid == guid);
        }

        public CourseContent GetCourseContentByGuid(string guid)
        {
            return DatabaseContext.CourseContents.FirstOrDefault(c => c.Guid == guid);
        }

        public ObservableCollection<Course> GetCourses()
        {
            ObservableCollection<Course> courses = new(DatabaseContext.Courses.ToList());
            return courses;
        }
         
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
            ObservableCollection<CourseChapter> chapters = new(DatabaseContext.CourseChapters.ToList());
            
            return AddAuthors<CourseChapter>(chapters);
        }

        public ObservableCollection<CourseChapter> GetCourseChapters(int courseId)
        {
            var chapters = new ObservableCollection<CourseChapter>(DatabaseContext.CourseChapters.Where(c => c.CourseId == courseId).ToList());
            return chapters;
        }

        public ObservableCollection<CourseChapter> GetCourseChapters(int chapterId, int courseId)
        {
            var chapters = new ObservableCollection<CourseChapter>(DatabaseContext.CourseChapters.Where(c => c.ChapterId == chapterId && c.CourseId == courseId).ToList());
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
            var lessons = new ObservableCollection<CourseLesson>(DatabaseContext.CourseLessons.ToList());
            return lessons;
        }

        public ObservableCollection<CourseLesson> GetCourseLessons(int chapterId)
        {
            var lessons = new ObservableCollection<CourseLesson>(DatabaseContext.CourseLessons.Where(l => l.ChapterId == chapterId).ToList());
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
            return new(DatabaseContext.CourseContents.ToList());
        }

        public SubContent GetContentFeilds(int contentId)
        {
            return DatabaseContext.CourseContents.Select(x => new SubContent
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
            return new(DatabaseContext.CourseContents.Select(x => new SubContent
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
            return new(DatabaseContext.CourseContents.Where(cc => cc.LessonId == lessonId).ToList());
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
            return new(DatabaseContext.CourseData.ToList());
        }

        public ObservableCollection<CourseDatum> GetCourseData(int enrollmentId)
        {
            return new(DatabaseContext.CourseData.Where(cd => cd.EnrollmentId == enrollmentId).ToList());
        }

        public CourseDatum GetCourseDatumByEnrollmentId(int enrollmentId)
        {
            return DatabaseContext.CourseData.FirstOrDefault(cd => cd.EnrollmentId == enrollmentId);
        }

		#endregion

		#region Selects


		public ObservableCollection<int> GetCourseIds()
		{
			return new ObservableCollection<int>(DatabaseContext.CourseChapters.Select(x => x.ChapterId).ToList());
		}

		public ObservableCollection<int> GetCourseChapterIds(int courseId)
		{
			return new ObservableCollection<int>(DatabaseContext.CourseChapters.OrderBy(x => x.ChapterNumber).Where(c => c.CourseId == courseId).Select(x => x.ChapterId).ToList());
		}

		public ObservableCollection<int> GetCourseLessonIds(int chapterId)
		{
			return new ObservableCollection<int>(DatabaseContext.CourseLessons.OrderBy(x => x.LessonNumber).Where(c => c.ChapterId == chapterId).Select(x => x.LessonId).ToList());
		}

		public ObservableCollection<int> GetCourseContentIds(int lessonId)
		{
			return new ObservableCollection<int>(DatabaseContext.CourseContents.OrderBy(x => x.ContentNumber).Where(c => c.LessonId == lessonId).Select(x => x.ContentId).ToList());
		}

		//public ObservableCollection<int, int> GetCourseIds()
		//{
		//	return new(DatabaseContext.CourseChapters.Select(x => x.ChapterId).ToList());
		//}

		public ObservableCollection<MiniINT> GetCourseChapterIdsAndNumber(int courseId)
		{
			return new(DatabaseContext.CourseChapters.OrderBy(x => x.ChapterNumber).Where(c => c.CourseId == courseId).Select(x => new MiniINT() { ObjectId = x.ChapterId, Number = x.ChapterNumber, Guid = x.Guid }).ToList());
		}

		public ObservableCollection<MiniINT> GetCourseLessonIdsAndNumber(int chapterId)
		{
			return new(DatabaseContext.CourseLessons.OrderBy(x => x.LessonNumber).Where(c => c.ChapterId == chapterId).Select(x => new MiniINT() { ObjectId = x.LessonId, Number = x.LessonNumber, Guid = x.Guid }).ToList());
		}

		public ObservableCollection<MiniINT> GetCourseContentIdsAndNumber(int lessonId)
		{
			return new (DatabaseContext.CourseContents.OrderBy(x => x.ContentNumber).Where(c => c.LessonId == lessonId).Select(x => new MiniINT() { ObjectId = x.ContentId, Number = x.ContentNumber, Guid = x.Guid } ).ToList());
		}
		#endregion

		#region Index_data
        public DataIndex GetDataIndex(int indexId)
        {
            return Crud.Read<DataIndex>(indexId, DatabaseContext);
		}
		public DataIndex GetDataIndexByCourseId(int courseId)
		{
			return DatabaseContext.DataIndices.FirstOrDefault(d => d.CourseId == courseId);
		}
		public ObservableCollection<DataIndex> GetDataIndices()
        {
            return new(DatabaseContext.DataIndices);
        }
        public ObservableCollection<DataIndex> GetDataIndices(int courseId)
        {
            return new(DatabaseContext.DataIndices.Where(i => i.CourseId == courseId));
        }
        public DataIndex GetCourseDataIndex(int courseId)
        {
            return DatabaseContext.DataIndices.FirstOrDefault(i => i.CourseId == courseId);
        }
		#endregion
	}
}
