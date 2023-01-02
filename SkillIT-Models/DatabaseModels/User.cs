using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class User
    {
        public User()
        {
            AccountDetails = new HashSet<AccountDetail>();
            Engagements = new HashSet<Engagement>();
            Enrollments = new HashSet<Enrollment>();
            Otps = new HashSet<Otp>();
            UserAchievements = new HashSet<UserAchievement>();
            UserCertificates = new HashSet<UserCertificate>();
            UserSkills = new HashSet<UserSkill>();
            UserSocials = new HashSet<UserSocial>();
        }

        public long UserId { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public string Phone { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
        public virtual ICollection<Engagement> Engagements { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Otp> Otps { get; set; }
        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
        public virtual ICollection<UserCertificate> UserCertificates { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<UserSocial> UserSocials { get; set; }
    }
}
