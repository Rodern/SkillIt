using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class AccountDetail
    {
        public AccountDetail()
        {
            Creators = new HashSet<Creator>();
        }

        public long AccountId { get; set; }
        public long UserId { get; set; }
        public string AccountType { get; set; }
        public int RoleId { get; set; }
        public DateTime LastLogin { get; set; }
        public string LoginInfo { get; set; }
        public string AccountStatus { get; set; }
        public string LoginAttemp { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Creator> Creators { get; set; }
    }
}
