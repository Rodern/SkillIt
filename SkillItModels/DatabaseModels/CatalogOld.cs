﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class CatalogOld
    {
        public CatalogOld()
        {
            UserAchievements = new HashSet<UserAchievement>();
        }

        public int CatalogId { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string CatalogLink { get; set; }

        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
