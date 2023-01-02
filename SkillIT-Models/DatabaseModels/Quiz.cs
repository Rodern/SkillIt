using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Quiz
    {
        public Quiz()
        {
            ChapterQuizzes = new HashSet<ChapterQuiz>();
            EnrollmentQuizzes = new HashSet<EnrollmentQuiz>();
            QuizQuestions = new HashSet<QuizQuestion>();
        }

        public int QuizId { get; set; }
        public long AuthorId { get; set; }
        public DateTime DateCreated { get; set; }
        public int? QuizCode { get; set; }

        public virtual ICollection<ChapterQuiz> ChapterQuizzes { get; set; }
        public virtual ICollection<EnrollmentQuiz> EnrollmentQuizzes { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
