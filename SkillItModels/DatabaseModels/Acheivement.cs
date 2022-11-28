using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class Acheivement
    {
        public Acheivement()
        {
            UserAchievements = new HashSet<UserAchievement>();
        }

        public int AchId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
