using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Email
    {
        public Email()
        {
            UserEmails = new HashSet<UserEmail>();
        }

        public long EmailId { get; set; }
        public string Address { get; set; }
        public bool IsPrimary { get; set; }
        public bool CanMailTo { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsVerified { get; set; }

        public virtual ICollection<UserEmail> UserEmails { get; set; }
    }
}
