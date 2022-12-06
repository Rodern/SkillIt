using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class Engagement
    {
        public int EngagementId { get; set; }
        public long UserId { get; set; }
        public int CatalogId { get; set; }
        public DateTime EngagedDate { get; set; }

        public virtual Catalog Catalog { get; set; }
        public virtual User User { get; set; }
    }
}
