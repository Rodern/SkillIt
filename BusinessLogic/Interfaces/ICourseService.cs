using SkillIT_Models.Entities.Courses;
using SkillIT_Models.Entities.Learning;
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
        ResponseModel CreateCourseDatum(CourseData courseData);
        ResponseModel CreateCourseLesson(CourseLesson courseLesson);
        ResponseModel DeleteCourse(long courseId);
        ResponseModel DeleteCourseChapter(long chapterId);
        ResponseModel DeleteCourseContent(long contentId);
        ResponseModel DeleteCourseDatum(long dataId);
        ResponseModel DeleteCourseLesson(long lessonId);
        Course? GetCourse(long courseId);
        Course? GetCourseByGuid(string guid);
        CourseChapter? GetCourseChapter(long chapterId);
		CourseChapter? GetCourseChapterByGuid(string guid);
		ObservableCollection<long> GetCourseChapterIds(long courseId);
		ObservableCollection<MiniINT> GetCourseChapterIdsAndNumber(long courseId);
		ObservableCollection<CourseChapter> GetCourseChapters();
        ObservableCollection<CourseChapter> GetCourseChapters(long courseId);
        ObservableCollection<CourseChapter> GetCourseChapters(long chapterId, long courseId);
        CourseContent? GetCourseContent(long contentId);
		CourseContent? GetCourseContentByGuid(string guid);
		ObservableCollection<long> GetCourseContentIds(long lessonId);
		ObservableCollection<MiniINT> GetCourseContentIdsAndNumber(long lessonId);
		ObservableCollection<CourseContent> GetCourseContents();
        ObservableCollection<CourseContent> GetCourseContents(long lessonId);
        ObservableCollection<CourseData> GetCourseData();
        ObservableCollection<CourseData> GetCourseData(long enrollmentId);
		DataIndex? GetCourseDataIndex(long courseId);
		CourseData? GetCourseDatum(long dataId);
		CourseData? GetCourseDatumByEnrollmentId(long enrollmentId);
		ObservableCollection<long> GetCourseIds();
		CourseLesson? GetCourseLesson(long lessonId);
		CourseLesson? GetCourseLessonByGuid(string guid);
		ObservableCollection<long> GetCourseLessonIds(long chapterId);
		ObservableCollection<MiniINT> GetCourseLessonIdsAndNumber(long chapterId);
		ObservableCollection<CourseLesson> GetCourseLessons();
        ObservableCollection<CourseLesson> GetCourseLessons(long chapterId);
        ObservableCollection<Course> GetCourses();
		DataIndex? GetDataIndex(long indexId);
		DataIndex? GetDataIndexByCourseId(long courseId);
		ObservableCollection<DataIndex> GetDataIndices();
		ObservableCollection<DataIndex> GetDataIndices(long id);
		ObservableCollection<CourseIndex> IndexCourse(long courseId);
		ResponseModel UpdateCourse(Course course);
        ResponseModel UpdateCourse(CourseChapter courseChapter);
        ResponseModel UpdateCourseContent(CourseContent content);
        ResponseModel UpdateCourseDatum(CourseData courseData);
        ResponseModel UpdateCourseLesson(CourseLesson courseLesson);
    }
}
