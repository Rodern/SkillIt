using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Question
    {
        public Question()
        {
            QuestionAnswerResponses = new HashSet<QuestionAnswerResponse>();
            QuestionAnswers = new HashSet<QuestionAnswer>();
            QuizQuestions = new HashSet<QuizQuestion>();
        }

        public int QuestionId { get; set; }
        public long AuthorId { get; set; }
        public string Question1 { get; set; }

        public virtual Creator Author { get; set; }
        public virtual ICollection<QuestionAnswerResponse> QuestionAnswerResponses { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
