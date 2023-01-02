using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Catalog
    {
        public Catalog()
        {
            Engagements = new HashSet<Engagement>();
            UserAchievements = new HashSet<UserAchievement>();
        }

        public int CatalogId { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Data { get; set; }
        public string CatalogLink { get; set; }

        public virtual ICollection<Engagement> Engagements { get; set; }
        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
