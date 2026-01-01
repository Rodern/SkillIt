using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Feedback
    {
        public long FeedbackId { get; set; }
        public long UserId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string IncludedImages { get; set; }
        public string ReadBy { get; set; }
        public bool IsRead { get; set; }
        public string TagIds { get; set; }
        public string TopicIds { get; set; }
        public string SubjectIds { get; set; }
        public string CategoryIds { get; set; }
        public string Response { get; set; }

        public virtual User User { get; set; }
    }
}
