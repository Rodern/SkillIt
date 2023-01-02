using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Skill
    {
        public Skill()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
