using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class UserAchievement
    {
        public int UserAchievementId { get; set; }
        public int AchievementId { get; set; }
        public long UserId { get; set; }
        public int? EnrollmentId { get; set; }
        public int? CatalogId { get; set; }
        public int? UserSkillId { get; set; }
        public int? LanguageId { get; set; }

        public virtual Achievement Achievement { get; set; }
        public virtual Catalog Catalog { get; set; }
        public virtual Enrollment Enrollment { get; set; }
        public virtual User User { get; set; }
        public virtual UserSkill UserSkill { get; set; }
    }
}
