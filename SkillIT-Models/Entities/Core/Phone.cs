using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("phone")]
public class Phone : AuditableEntity
{
    [Column("phoneId")]
    public override long Id { get; set; }

    [Required]
    [Column("countryId")]
    public long CountryId { get; set; }  // Changed from int to long

    [Required]
    [Column("number")]
    public int Number { get; set; }

    [Column("is_primary")]
    public bool IsPrimary { get; set; }

    [Column("can_notify")]
    public bool CanNotify { get; set; } = false;

    [Column("is_verified")]
    public bool IsVerified { get; set; } = false;

    [Required]
    [Column("type")]
    public PhoneType Type { get; set; }

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime? LastModified { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<UserPhone> UserPhones { get; set; } = new List<UserPhone>();
}

public enum PhoneType
{
    home,
    mobile,
    fax,
    office,
    work
}

[Table("user_phone")]
public class UserPhone : BaseEntity
{
    [Column("user_phoneId")]
    public override long Id { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [Column("phoneId")]
    public long PhoneId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(PhoneId))]
    public virtual Phone Phone { get; set; } = null!;
}
