using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class EnrollmentQuiz
    {
        public int EnrollmentQuizId { get; set; }
        public int EnrollmentId { get; set; }
        public int QuizId { get; set; }
        public DateTime DateTaken { get; set; }
        public bool Passed { get; set; }
        public int Points { get; set; }
        public float TimeTaken { get; set; }

        public virtual Enrollment Enrollment { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
