using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Learning;

namespace SkillIT_Models.Entities.Courses;

[Table("course")]
public class Course : AuditableEntity
{
    [Column("courseID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(36)] // Changed from 100 to 36 for GUIDs
    [Column("guid")]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();

    [Required]
    [MaxLength(250)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("description", TypeName = "text")] // Changed from longtext to text
    public string Description { get; set; } = string.Empty;

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    [Column("date_publish")]
    public DateTime DatePublish { get; set; }

    [Column("is_published")]
    public bool IsPublished { get; set; } = false;

    [Column("is_open")]
    public bool IsOpen { get; set; } = true;

    [Column("authorID")]
    public long? AuthorId { get; set; }

    [Required]
    [Column("level")]
    public CourseLevel Level { get; set; } = CourseLevel.general;

    [MaxLength(250)]
    [Column("cover_image")]
    public string CoverImage { get; set; } = "default.png";

    // Navigation properties
    [ForeignKey(nameof(AuthorId))]
    public virtual Creator? Author { get; set; }

    public virtual ICollection<CourseChapter> Chapters { get; set; } = new List<CourseChapter>();
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public virtual ICollection<DataIndex> DataIndexes { get; set; } = new List<DataIndex>();
    public virtual ICollection<UserCertificate> Certificates { get; set; } = new List<UserCertificate>();
}

public enum CourseLevel
{
    general,
    beginner,
    intermediate,
    advance
}
