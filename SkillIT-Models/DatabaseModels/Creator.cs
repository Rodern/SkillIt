using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Creator
    {
        public Creator()
        {
            ChapterQuizzes = new HashSet<ChapterQuiz>();
            CourseChapters = new HashSet<CourseChapter>();
            CourseContents = new HashSet<CourseContent>();
            CourseLessons = new HashSet<CourseLesson>();
            Courses = new HashSet<Course>();
            Questions = new HashSet<Question>();
        }

        public long AuthorId { get; set; }
        public long AccountId { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }

        public virtual AccountDetail Account { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<ChapterQuiz> ChapterQuizzes { get; set; }
        public virtual ICollection<CourseChapter> CourseChapters { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }
        public virtual ICollection<CourseLesson> CourseLessons { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
