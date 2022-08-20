using System;
using System.Collections.Generic;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class User
    {
        public User()
        {
            //this.Address = user.Address;
            //this.Username = user.Username;
            //this.FirstName = user.FirstName;
            //this.LastName = user.LastName;
            //this.Email = user.Email;
            //this.Phone = user.Phone;
            //this.Password = user.Password;
            //this.UserSkillId = user.UserSkillId;
            //this.UserId = user.UserId;
            //this.UserSocialId = user.UserSocialId;
            AccountDetails = new HashSet<AccountDetail>();
            UserSkills = new HashSet<UserSkill>();
            UserSocials = new HashSet<UserSocial>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public string Phone { get; set; }
        public int? UserSocialId { get; set; }
        public int? UserSkillId { get; set; }

        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<UserSocial> UserSocials { get; set; }
    }
}
