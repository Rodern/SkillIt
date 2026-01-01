using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
    public class AuthenticatedModel
    {
        public AuthenticatedModel(long userId, string token)
        {
            UserId = userId;
            Token = token;
        }
        public long UserId { get; set; }
        public string Token { get; set; }
    }
}
