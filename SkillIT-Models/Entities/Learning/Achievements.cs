using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Courses;

namespace SkillIT_Models.Entities.Learning;

[Table("achievement")]
public class Achievement : BaseEntity
{
    [Column("achievementID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Column("type")]
    public AchievementType Type { get; set; }

    // Navigation properties
    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}

public enum AchievementType
{
    [Display(Name = "Course Completion")]
    course_completion,
    [Display(Name = "Skill Mastery")]
    skill_mastery,
    [Display(Name = "Quiz Master")]
    quiz_master,
    [Display(Name = "Speed Learner")]
    speed_learner,
    [Display(Name = "Perfect Score")]
    perfect_score
}

[Table("user_achievement")]
public class UserAchievement : BaseEntity
{
    [Column("user_achievementID")]
    public override long Id { get; set; }

    [Required]
    [Column("achievementID")]
    public long AchievementId { get; set; }

    [Required]
    [Column("userID")]
    public long UserId { get; set; }

    [Column("enrollmentID")]
    public long? EnrollmentId { get; set; }

    [Column("catalogID")]
    public long? CatalogId { get; set; }

    [Column("user_skillID")]
    public long? UserSkillId { get; set; }

    [Column("languageID")]
    public long? LanguageId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(AchievementId))]
    public virtual Achievement Achievement { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(EnrollmentId))]
    public virtual Enrollment? Enrollment { get; set; }

    [ForeignKey(nameof(CatalogId))]
    public virtual Catalog? Catalog { get; set; }

    [ForeignKey(nameof(UserSkillId))]
    public virtual UserSkill? UserSkill { get; set; }
}

[Table("certificate")]
public class Certificate : BaseEntity
{
    [Column("certificateID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(250)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Column("type")]
    public CertificateType Type { get; set; }

    [Column("date_issued")]
    public DateTime? DateIssued { get; set; }

    [Column("date_expired")]
    public DateTime? DateExpired { get; set; }

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual ICollection<UserCertificate> UserCertificates { get; set; } = new List<UserCertificate>();
}

public enum CertificateType
{
    [Display(Name = "Course Completion")]
    course_completion,
    [Display(Name = "Skill Certification")]
    skill_certification,
    [Display(Name = "Professional")]
    professional
}

[Table("user_certificate")]
public class UserCertificate : BaseEntity
{
    [Column("user_certificateID")]
    public override long Id { get; set; }

    [Required]
    [Column("certificateID")]
    public long CertificateId { get; set; }

    [Required]
    [Column("userID")]
    public long UserId { get; set; }

    [Column("courseID")]
    public long? CourseId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CertificateId))]
    public virtual Certificate Certificate { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(CourseId))]
    public virtual Course? Course { get; set; }
}
