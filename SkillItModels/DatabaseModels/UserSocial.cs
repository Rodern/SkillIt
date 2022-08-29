using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class UserSocial
    {
        public int UserSocialId { get; set; }
        public int SocialId { get; set; }
        public long UserId { get; set; }

        public virtual Social Social { get; set; }
        public virtual User User { get; set; }
    }
}
