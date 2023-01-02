using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Otp
    {
        public long OtpId { get; set; }
        public int Code { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
