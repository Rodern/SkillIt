using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Enrollment
    {
        public Enrollment()
        {
            CourseData = new HashSet<CourseDatum>();
            EnrollmentQuizzes = new HashSet<EnrollmentQuiz>();
            QuestionAnswerResponses = new HashSet<QuestionAnswerResponse>();
            UserAchievements = new HashSet<UserAchievement>();
        }

        public int EnrollmentId { get; set; }
        public long UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateEnrolled { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CourseDatum> CourseData { get; set; }
        public virtual ICollection<EnrollmentQuiz> EnrollmentQuizzes { get; set; }
        public virtual ICollection<QuestionAnswerResponse> QuestionAnswerResponses { get; set; }
        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
