using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Learning;

namespace SkillIT_Models.Entities.Core;

[Table("user")]
public class User : AuditableEntity
{
    [Column("userID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(15)]
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(15)]
    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    [Column("username")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)] // Increased for future-proofing (Argon2 compatibility)
    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Column("dob")]
    public DateTime DateOfBirth { get; set; }

    [MaxLength(100)]
    [Column("address")]
    public string Address { get; set; } = string.Empty;

    [Required]
    [Column("gender")]
    public Gender Gender { get; set; }

    [MaxLength(20)]
    [Column("phone")]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(250)]
    [Column("profile_image")]
    public string ProfileImage { get; set; } = string.Empty;

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual Account? Account { get; set; }
    public virtual ICollection<UserEmail> UserEmails { get; set; } = new List<UserEmail>();
    public virtual ICollection<UserPhone> UserPhones { get; set; } = new List<UserPhone>();
    public virtual ICollection<UserCity> UserCities { get; set; } = new List<UserCity>();
    public virtual ICollection<UserCountry> UserCountries { get; set; } = new List<UserCountry>();
    public virtual ICollection<UserRegion> UserRegions { get; set; } = new List<UserRegion>();
    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
    public virtual ICollection<UserSocial> UserSocials { get; set; } = new List<UserSocial>();
    public virtual ICollection<Password> Passwords { get; set; } = new List<Password>();
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public virtual ICollection<Engagement> Engagements { get; set; } = new List<Engagement>();
    public virtual ICollection<UserAchievement> Achievements { get; set; } = new List<UserAchievement>();
    public virtual ICollection<UserCertificate> Certificates { get; set; } = new List<UserCertificate>();
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public virtual ICollection<Otp> Otps { get; set; } = new List<Otp>();
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    public virtual Testimonial? Testimonial { get; set; }
}

public enum Gender
{
    M,
    F,
    Other
}
