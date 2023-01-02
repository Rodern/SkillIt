using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Certificate
    {
        public Certificate()
        {
            UserCertificates = new HashSet<UserCertificate>();
        }

        public int CertificateId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SignedDate { get; set; }
        public string Platform { get; set; }
        public string Link { get; set; }

        public virtual ICollection<UserCertificate> UserCertificates { get; set; }
    }
}
