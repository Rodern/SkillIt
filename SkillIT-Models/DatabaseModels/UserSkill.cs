using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class UserSkill
    {
        public UserSkill()
        {
            UserAchievements = new HashSet<UserAchievement>();
        }

        public int UserSkillId { get; set; }
        public int SkillId { get; set; }
        public long UserId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
