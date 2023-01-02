using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class QuestionAnswerResponse
    {
        public int QuestionAnswerResponseId { get; set; }
        public int QuestionId { get; set; }
        public int EnrollmentId { get; set; }
        public int QuestionAnswerId { get; set; }
        public DateTime TimeAnswer { get; set; }

        public virtual Enrollment Enrollment { get; set; }
        public virtual Question Question { get; set; }
        public virtual QuestionAnswer QuestionAnswer { get; set; }
    }
}
