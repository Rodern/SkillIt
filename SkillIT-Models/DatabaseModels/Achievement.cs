using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Achievement
    {
        public Achievement()
        {
            UserAchievements = new HashSet<UserAchievement>();
        }

        public int AchievementId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
