using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Core;

namespace SkillIT_Models.Entities.Learning;

[Table("catalog")]
public class Catalog : AuditableEntity
{
    [Column("catalogID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(250)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    // FIXED: Changed from LONGBLOB to URL
    [MaxLength(500)]
    [Column("image_url")]
    public string ImageUrl { get; set; } = "default.png";

    [MaxLength(500)]
    [Column("image_thumbnail_url")]
    public string? ImageThumbnailUrl { get; set; }

    [Required]
    [Column("data", TypeName = "json")] // Changed from longtext to json
    public string Data { get; set; } = "{}";

    [Required]
    [Column("descriptions", TypeName = "text")]
    public string Descriptions { get; set; } = string.Empty;

    [Required]
    [Column("link", TypeName = "text")]
    public string Link { get; set; } = string.Empty;

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual ICollection<Engagement> Engagements { get; set; } = new List<Engagement>();
    public virtual ICollection<UserAchievement> Achievements { get; set; } = new List<UserAchievement>();
}

[Table("engagement")]
public class Engagement : AuditableEntity
{
    [Column("engagementID")]
    public override long Id { get; set; }

    [Required]
    [Column("userID")]
    public long UserId { get; set; }

    [Required]
    [Column("catalogID")]
    public long CatalogId { get; set; }

    [Column("engagedDate")]
    public DateTime EngagedDate { get; set; } = DateTime.UtcNow;

    [Column("completed")]
    public bool Completed { get; set; } = false;

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(CatalogId))]
    public virtual Catalog Catalog { get; set; } = null!;
}
