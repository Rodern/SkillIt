using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class CourseDatum
    {
        public int DataId { get; set; }
        public int EnrollmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastModified { get; set; }
        public string StudyRecord { get; set; }

        public virtual Enrollment Enrollment { get; set; }
    }
}
