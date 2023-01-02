using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Social
    {
        public Social()
        {
            UserSocials = new HashSet<UserSocial>();
        }

        public int SocialId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public virtual ICollection<UserSocial> UserSocials { get; set; }
    }
}
