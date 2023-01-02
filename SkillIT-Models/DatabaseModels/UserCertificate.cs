using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class UserCertificate
    {
        public int UserCertificateId { get; set; }
        public int CertificateId { get; set; }
        public long UserId { get; set; }
        public int? CourseId { get; set; }

        public virtual Certificate Certificate { get; set; }
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
