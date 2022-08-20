using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class UserSkill
    {
        public int UserSkillId { get; set; }
        public int SkillId { get; set; }
        public int UserId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual User User { get; set; }
    }
}
