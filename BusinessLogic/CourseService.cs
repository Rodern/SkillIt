using BusinessLogic.Interfaces;
using SkillIT_Models.CRUD;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CourseService: ICourseService
    {
        private readonly skill_it_dbContext DatabaseContext;

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

        public ObservableCollection<Course> GetCourses()
        {
            return new(DatabaseContext.Courses.ToList());
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
            return new(DatabaseContext.CourseChapters.ToList());
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
            return new(DatabaseContext.CourseLessons.ToList());
        }
        #endregion

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
        #endregion

        #region CourseData
        public ResponseModel CreateCourseDatum(CourseDatum courseData)
        {
            return Crud.Create(courseData.DataId, courseData, DatabaseContext);
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
        #endregion

    }
}
