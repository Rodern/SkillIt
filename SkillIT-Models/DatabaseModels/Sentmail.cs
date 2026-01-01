using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Sentmail
    {
        public int MailId { get; set; }
        public long UserId { get; set; }
        public string EmailBody { get; set; }
        public DateTime DateSent { get; set; }
        public string EmailType { get; set; }
    }
}
