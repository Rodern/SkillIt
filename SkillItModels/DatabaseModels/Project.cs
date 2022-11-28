using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string SoureLink { get; set; }
        public string Link { get; set; }
        public string SkillSet { get; set; }
        public long UserId { get; set; }
    }
}
