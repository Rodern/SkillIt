using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class UserPhone
    {
        public long UserPhoneId { get; set; }
        public long UserId { get; set; }
        public long PhoneId { get; set; }

        public virtual Phone Phone { get; set; }
        public virtual User User { get; set; }
    }
}
