using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("notification")]
public class Notification : AuditableEntity
{
    [Column("notificationId")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(36)]
    [Column("notification_guid")]
    public string NotificationGuid { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [Column("accountId")]
    public long AccountId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("caption")]
    public string Caption { get; set; } = string.Empty;

    [Required]
    [MaxLength(250)]
    [Column("details")]
    public string Details { get; set; } = string.Empty;

    // JSON column - will be configured in Fluent API
    [Column("actions", TypeName = "json")]
    public string Actions { get; set; } = "[]";

    [MaxLength(250)]
    [Column("icon")]
    public string Icon { get; set; } = "notify.png";

    [Column("marked_as_read")]
    public bool MarkedAsRead { get; set; } = false;

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("date_read")]
    public DateTime? DateRead { get; set; }

    // Navigation properties
    [ForeignKey(nameof(AccountId))]
    public virtual Account Account { get; set; } = null!;
}

[Table("otp")]
public class Otp : BaseEntity
{
    [Column("otpID")]
    public override long Id { get; set; }

    [Required]
    [Column("code")]
    public int Code { get; set; }

    [Required]
    [Column("expiryDate")]
    public DateTime ExpiryDate { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [MaxLength(36)]
    [Column("guid")]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}

[Table("feedback")]
public class Feedback : AuditableEntity
{
    [Column("feedbackId")]
    public override long Id { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("subject")]
    public string Subject { get; set; } = string.Empty;

    [Required]
    [Column("content", TypeName = "text")]
    public string Content { get; set; } = string.Empty;

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("date_modified")]
    public DateTime DateModified { get; set; } = DateTime.UtcNow;

    // JSON columns
    [Column("included_images", TypeName = "json")]
    public string IncludedImages { get; set; } = "[]";

    [Column("read_by", TypeName = "json")]
    public string ReadBy { get; set; } = "[]";

    [Column("is_read")]
    public bool IsRead { get; set; } = false;

    [Column("tag_ids", TypeName = "json")]
    public string TagIds { get; set; } = "[]";

    [Column("topic_ids", TypeName = "json")]
    public string TopicIds { get; set; } = "[]";

    [Column("subject_ids", TypeName = "json")]
    public string SubjectIds { get; set; } = "[]";

    [Column("category_ids", TypeName = "json")]
    public string CategoryIds { get; set; } = "[]";

    [Column("response", TypeName = "text")]
    public string Response { get; set; } = string.Empty;

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}

[Table("testimonial")]
public class Testimonial : AuditableEntity
{
    [Column("testimonialId")]
    public override long Id { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [Column("content", TypeName = "text")]
    public string Content { get; set; } = string.Empty;

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    [Column("is_approved")]
    public bool IsApproved { get; set; } = false;

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}

[Table("project")]
public class Project : BaseEntity
{
    [Column("projectID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(500)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("owner")]
    public string Owner { get; set; } = string.Empty;

    [MaxLength(2000)]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("soureLink")] // Keep typo from original DB
    public string SourceLink { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("link")]
    public string Link { get; set; } = string.Empty;

    [Column("skillSet", TypeName = "json")]
    public string SkillSet { get; set; } = "[]";

    [Required]
    [Column("userID")]
    public long UserId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}

[Table("sentmails")]
public class SentMail : BaseEntity
{
    [Column("mailId")]
    public override long Id { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [Column("email_body", TypeName = "text")]
    public string EmailBody { get; set; } = string.Empty;

    [Column("date_sent")]
    public DateTime DateSent { get; set; } = DateTime.UtcNow;

    [Required]
    [Column("email_type")]
    public EmailSentType EmailType { get; set; }
}

public enum EmailSentType
{
    verify_email,
    course_completed,
    course_registered,
    reset_password,
    welcome_email
}
