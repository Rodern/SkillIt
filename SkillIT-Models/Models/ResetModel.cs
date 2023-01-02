using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
    public class ResetModel
    {
        public long UserId { get; set; }
        public long OtpId { get; set; }
        public int Otp { get; set; }
        public string Password { get; set; }
    }
}
