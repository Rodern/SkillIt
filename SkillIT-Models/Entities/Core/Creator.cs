using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Courses;
using SkillIT_Models.Entities.Learning;

namespace SkillIT_Models.Entities.Core;

[Table("creator")]
public class Creator : BaseEntity
{
    [Column("authorID")]
    public override long Id { get; set; }

    [Required]
    [Column("accountID")]
    public long AccountId { get; set; }

    [Required]
    [Column("roleID")]
    public long RoleId { get; set; }

    [Required]
    [Column("status")]
    public CreatorStatus Status { get; set; } = CreatorStatus.active;

    // Navigation properties
    [ForeignKey(nameof(AccountId))]
    public virtual Account Account { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public virtual ICollection<CourseChapter> Chapters { get; set; } = new List<CourseChapter>();
    public virtual ICollection<CourseLesson> Lessons { get; set; } = new List<CourseLesson>();
    public virtual ICollection<CourseContent> Contents { get; set; } = new List<CourseContent>();
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}

public enum CreatorStatus
{
    active,
    passive
}
