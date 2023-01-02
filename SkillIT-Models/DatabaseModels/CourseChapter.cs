using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class CourseChapter
    {
        public CourseChapter()
        {
            ChapterQuizzes = new HashSet<ChapterQuiz>();
            CourseLessons = new HashSet<CourseLesson>();
        }

        public int ChapterId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public long AuthorId { get; set; }
        public int ChapterNumber { get; set; }

        public virtual Creator Author { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<ChapterQuiz> ChapterQuizzes { get; set; }
        public virtual ICollection<CourseLesson> CourseLessons { get; set; }
    }
}
