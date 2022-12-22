using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class UserCertificate
    {
        public int UcId { get; set; }
        public int CertId { get; set; }
        public long UserId { get; set; }

        public virtual Certificate Cert { get; set; }
        public virtual User User { get; set; }
    }
}
