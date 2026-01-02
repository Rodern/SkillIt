using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Learning;

namespace SkillIT_Models.Entities.Core;

[Table("skill")]
public class Skill : BaseEntity
{
    [Column("skillID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("level")]
    public SkillLevel Level { get; set; }

    // Navigation properties
    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}

public enum SkillLevel
{
    Beginner,
    Amateur,
    Intermediate,
    Professional,
    GodLevel
}

[Table("user_skill")]
public class UserSkill : BaseEntity
{
    [Column("user_skillID")]
    public override long Id { get; set; }

    [Required]
    [Column("skillID")]
    public long SkillId { get; set; }

    [Required]
    [Column("userID")]
    public long UserId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(SkillId))]
    public virtual Skill Skill { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserAchievement> Achievements { get; set; } = new List<UserAchievement>();
}

[Table("social")]
public class Social : BaseEntity
{
    [Column("socialID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("link")]
    public string Link { get; set; } = string.Empty;

    // Navigation properties
    public virtual ICollection<UserSocial> UserSocials { get; set; } = new List<UserSocial>();
}

[Table("user_social")]
public class UserSocial : BaseEntity
{
    [Column("user_socialID")]
    public override long Id { get; set; }

    [Required]
    [Column("socialID")]
    public long SocialId { get; set; }

    [Required]
    [Column("userID")]
    public long UserId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(SocialId))]
    public virtual Social Social { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}
