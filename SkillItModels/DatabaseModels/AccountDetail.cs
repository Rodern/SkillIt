using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class AccountDetail
    {
        public int AcId { get; set; }
        public long UserId { get; set; }
        public string AccountType { get; set; }
        public DateTime LastLogin { get; set; }
        public string LoginInfo { get; set; }
        public string AccountStatus { get; set; }
        public string LoginAttemp { get; set; }

        public virtual User User { get; set; }
    }
}
