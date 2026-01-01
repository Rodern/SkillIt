using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("email")]
public class Email : AuditableEntity
{
    [Column("emailId")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("address")]
    public string Address { get; set; } = string.Empty;

    [Column("is_primary")]
    public bool IsPrimary { get; set; }

    [Column("can_mail_to")]
    public bool CanMailTo { get; set; } = false;

    [Required]
    [Column("type")]
    public EmailType Type { get; set; }

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime? LastModified { get; set; }

    [Column("is_verified")]
    public bool IsVerified { get; set; } = false;

    // Navigation properties
    public virtual ICollection<UserEmail> UserEmails { get; set; } = new List<UserEmail>();
}

public enum EmailType
{
    personal,
    school,
    work
}

[Table("user_email")]
public class UserEmail : BaseEntity
{
    [Column("user_emailId")]
    public override long Id { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [Column("emailId")]
    public long EmailId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(EmailId))]
    public virtual Email Email { get; set; } = null!;
}
