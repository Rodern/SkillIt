using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            Engagements = new HashSet<Engagement>();
            Enrollments = new HashSet<Enrollment>();
            Feedbacks = new HashSet<Feedback>();
            Otps = new HashSet<Otp>();
            Projects = new HashSet<Project>();
            UserAchievements = new HashSet<UserAchievement>();
            UserCertificates = new HashSet<UserCertificate>();
            UserEmails = new HashSet<UserEmail>();
            UserSkills = new HashSet<UserSkill>();
            UserSocials = new HashSet<UserSocial>();
        }

        public long UserId { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public string Phone { get; set; }
        public string ProfileImage { get; set; }

        public virtual Testimonial Testimonial { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Engagement> Engagements { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Otp> Otps { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
        public virtual ICollection<UserCertificate> UserCertificates { get; set; }
        public virtual ICollection<UserEmail> UserEmails { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<UserSocial> UserSocials { get; set; }
    }
}
