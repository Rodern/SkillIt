using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class QuestionAnswer
    {
        public QuestionAnswer()
        {
            QuestionAnswerResponses = new HashSet<QuestionAnswerResponse>();
        }

        public int QuestionAnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<QuestionAnswerResponse> QuestionAnswerResponses { get; set; }
    }
}
