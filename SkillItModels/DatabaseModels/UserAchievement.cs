using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class UserAchievement
    {
        public int UaId { get; set; }
        public int AchId { get; set; }
        public long UserId { get; set; }
        public long? CourseId { get; set; }
        public int? CatalogId { get; set; }
        public int? UserSkillId { get; set; }
        public int? LanguageId { get; set; }

        public virtual Achievement Ach { get; set; }
        public virtual CatalogOld Catalog { get; set; }
        public virtual User User { get; set; }
        public virtual UserSkill UserSkill { get; set; }
    }
}
