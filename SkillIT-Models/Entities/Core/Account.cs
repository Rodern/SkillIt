using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("account")]
public class Account : AuditableEntity
{
    [Column("accountID")]
    public override long Id { get; set; }

    [Required]
    [Column("userID")]
    public long UserId { get; set; }

    [Required]
    [Column("roleID")]
    public long RoleId { get; set; }

    [Required]
    [Column("accountType")]
    public AccountType AccountType { get; set; }

    [Required]
    [Column("status")]
    public AccountStatus Status { get; set; }

    [Column("last_login")]
    public DateTime? LastLogin { get; set; }

    [Column("last_logout")]
    public DateTime? LastLogout { get; set; }

    // JSON columns - will be configured in Fluent API
    [Column("login_info", TypeName = "json")]
    public string LoginInfo { get; set; } = "{}";

    [Column("login_attemp", TypeName = "json")]
    public string LoginAttempt { get; set; } = "{}";

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public virtual Creator? Creator { get; set; }
}

public enum AccountType
{
    [Display(Name = "Admin")]
    admin,
    [Display(Name = "User")]
    user,
    [Display(Name = "Creator")]
    creator,
    [Display(Name = "Guest")]
    guest
}

public enum AccountStatus
{
    [Display(Name = "Active")]
    ACTIVE,
    [Display(Name = "Passive")]
    PASSIVE,
    [Display(Name = "Verified")]
    VERIFIED,
    [Display(Name = "Not Verified")]
    NOT_VERIFIED
}
