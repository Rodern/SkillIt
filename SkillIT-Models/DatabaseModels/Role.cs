using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Role
    {
        public Role()
        {
            AccountDetails = new HashSet<AccountDetail>();
            Creators = new HashSet<Creator>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
        public virtual ICollection<Creator> Creators { get; set; }
    }
}
