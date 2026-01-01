using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Phone
    {
        public long PhoneId { get; set; }
        public int CountryId { get; set; }
        public int Number { get; set; }
        public bool IsPrimary { get; set; }
        public bool CanNotify { get; set; }
        public bool IsVerified { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Country Country { get; set; }
    }
}
