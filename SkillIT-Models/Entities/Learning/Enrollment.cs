using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Courses;

namespace SkillIT_Models.Entities.Learning;

[Table("enrollment")]
public class Enrollment : AuditableEntity
{
    [Column("enrollmentID")]
    public override long Id { get; set; }

    [Required]
    [Column("userID")]
    public long UserId { get; set; }

    [Required]
    [Column("courseID")]
    public long CourseId { get; set; }

    [Column("date_enrolled")]
    public DateTime DateEnrolled { get; set; } = DateTime.UtcNow;

    [Column("is_completed")]
    public bool IsCompleted { get; set; } = false;

    [Column("date_completed")]
    public DateTime DateCompleted { get; set; }

    [Column("completion_percentage")]
    public decimal CompletionPercentage { get; set; } = 0;

    [Column("last_accessed")]
    public DateTime? LastAccessed { get; set; }

    [Column("enrolled_at")]
    public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<CourseData> CourseData { get; set; } = new List<CourseData>();
    public virtual ICollection<EnrollmentQuiz> EnrollmentQuizzes { get; set; } = new List<EnrollmentQuiz>();
    public virtual ICollection<QuestionAnswerResponse> QuestionAnswerResponses { get; set; } = new List<QuestionAnswerResponse>();
    public virtual ICollection<UserAchievement> Achievements { get; set; } = new List<UserAchievement>();
}

[Table("course_data")]
public class CourseData : AuditableEntity
{
    [Column("dataID")]
    public override long Id { get; set; }

    [Required]
    [Column("enrollmentID")]
    public long EnrollmentId { get; set; }

    [Column("start_date")]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    // JSON column - will be configured in Fluent API
    [Column("study_record", TypeName = "json")]
    public string StudyRecord { get; set; } = "[]";

    // Navigation properties
    [ForeignKey(nameof(EnrollmentId))]
    public virtual Enrollment Enrollment { get; set; } = null!;
}

[Table("data_index")]
public class DataIndex : BaseEntity
{
    [Column("indexId")]
    public override long Id { get; set; }

    [Required]
    [Column("courseId")]
    public long CourseId { get; set; }

    // JSON column - will be configured in Fluent API
    [Column("index_data", TypeName = "json")]
    public string IndexData { get; set; } = "[]";

    [Column("last_modified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    // Navigation properties
    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; } = null!;
}
