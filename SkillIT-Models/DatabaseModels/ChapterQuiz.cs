using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class ChapterQuiz
    {
        public int ChapterQuizId { get; set; }
        public int QuizId { get; set; }
        public int ChapterId { get; set; }
        public DateTime DateCreated { get; set; }
        public long AuthorId { get; set; }

        public virtual Creator Author { get; set; }
        public virtual CourseChapter Chapter { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
