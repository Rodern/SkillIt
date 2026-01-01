using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class DataIndex
    {
        public int IndexId { get; set; }
        public int CourseId { get; set; }
        public string IndexData { get; set; }
        public DateTime LastModified { get; set; }
    }
}
