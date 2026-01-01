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
        Course GetCourseByGuid(string guid);
        CourseChapter GetCourseChapter(int chapterId);
		CourseChapter GetCourseChapterByGuid(string guid);
		ObservableCollection<int> GetCourseChapterIds(int courseId);
		ObservableCollection<MiniINT> GetCourseChapterIdsAndNumber(int courseId);
		ObservableCollection<CourseChapter> GetCourseChapters();
        ObservableCollection<CourseChapter> GetCourseChapters(int courseId);
        ObservableCollection<CourseChapter> GetCourseChapters(int chapterId, int courseId);
        CourseContent GetCourseContent(int contentId);
		CourseContent GetCourseContentByGuid(string guid);
		ObservableCollection<int> GetCourseContentIds(int lessonId);
		ObservableCollection<MiniINT> GetCourseContentIdsAndNumber(int lessonId);
		ObservableCollection<CourseContent> GetCourseContents();
        ObservableCollection<CourseContent> GetCourseContents(int lessonId);
        ObservableCollection<CourseDatum> GetCourseData();
        ObservableCollection<CourseDatum> GetCourseData(int enrollmentId);
		DataIndex GetCourseDataIndex(int courseId);
		CourseDatum GetCourseDatum(int dataId);
		CourseDatum GetCourseDatumByEnrollmentId(int enrollmentId);
		ObservableCollection<int> GetCourseIds();
		CourseLesson GetCourseLesson(int lessonId);
		CourseLesson GetCourseLessonByGuid(string guid);
		ObservableCollection<int> GetCourseLessonIds(int chapterId);
		ObservableCollection<MiniINT> GetCourseLessonIdsAndNumber(int chapterId);
		ObservableCollection<CourseLesson> GetCourseLessons();
        ObservableCollection<CourseLesson> GetCourseLessons(int chapterId);
        ObservableCollection<Course> GetCourses();
		DataIndex GetDataIndex(int indexId);
		DataIndex GetDataIndexByCourseId(int courseId);
		ObservableCollection<DataIndex> GetDataIndices();
		ObservableCollection<DataIndex> GetDataIndices(int id);
		ObservableCollection<CourseIndex> IndexCourse(int courseId);
		ResponseModel UpdateCourse(Course course);
        ResponseModel UpdateCourse(CourseChapter courseChapter);
        ResponseModel UpdateCourseContent(CourseContent content);
        ResponseModel UpdateCourseDatum(CourseDatum courseData);
        ResponseModel UpdateCourseLesson(CourseLesson courseLesson);
    }
}
