using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICourseService
    {
        ResponseModel CreateCourse(Course course);
        ResponseModel CreateCourseChapter(CourseChapter courseChapter);
        ResponseModel CreateCourseContent(CourseContent content);
        ResponseModel CreateCourseDatum(CourseDatum courseData);
        ResponseModel CreateCourseLesson(CourseLesson courseLesson);
        ResponseModel DeleteCourse(int courseId);
        ResponseModel DeleteCourseChapter(int chapterId);
        ResponseModel DeleteCourseContent(int contentId);
        ResponseModel DeleteCourseDatum(int dataId);
        ResponseModel DeleteCourseLesson(int lessonId);
        Course GetCourse(int courseId);
        CourseChapter GetCourseChapter(int chapterId);
        ObservableCollection<CourseChapter> GetCourseChapters();
        CourseContent GetCourseContent(int contentId);
        ObservableCollection<CourseContent> GetCourseContents();
        ObservableCollection<CourseDatum> GetCourseData();
        CourseDatum GetCourseDatum(int dataId);
        CourseLesson GetCourseLesson(int lessonId);
        ObservableCollection<CourseLesson> GetCourseLessons();
        ObservableCollection<Course> GetCourses();
        ResponseModel UpdateCourse(Course course);
        ResponseModel UpdateCourse(CourseChapter courseChapter);
        ResponseModel UpdateCourseContent(CourseContent content);
        ResponseModel UpdateCourseDatum(CourseDatum courseData);
        ResponseModel UpdateCourseLesson(CourseLesson courseLesson);
    }
}
