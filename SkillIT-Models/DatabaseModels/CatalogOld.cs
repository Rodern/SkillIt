﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class CatalogOld
    {
        public int CatalogId { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string CatalogLink { get; set; }
    }
}
