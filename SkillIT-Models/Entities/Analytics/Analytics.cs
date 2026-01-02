using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Courses;

namespace SkillIT_Models.Entities.Analytics;

/// <summary>
/// Tracks when users view course details
/// </summary>
[Table("course_views")]
public class CourseView : BaseEntity
{
    [Column("id")]
    public override long Id { get; set; }

    [Required]
    [Column("course_id")]
    public long CourseId { get; set; }

    [Required]
    [Column("user_id")]
    public long UserId { get; set; }

    [Column("viewed_at")]
    public DateTime ViewedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(45)]
    [Column("ip_address")]
    public string? IpAddress { get; set; }

    [MaxLength(500)]
    [Column("user_agent")]
    public string? UserAgent { get; set; }

    [MaxLength(2083)]
    [Column("referrer_url")]
    public string? ReferrerUrl { get; set; }

    [Column("session_duration_seconds")]
    public int? SessionDurationSeconds { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}

/// <summary>
/// Tracks course enrollment events (denormalized for analytics)
/// </summary>
[Table("course_enrollments_analytics")]
public class CourseEnrollmentAnalytics : BaseEntity
{
    [Column("id")]
    public override long Id { get; set; }

    [Required]
    [Column("enrollment_id")]
    public long EnrollmentId { get; set; }

    [Required]
    [Column("course_id")]
    public long CourseId { get; set; }

    [Required]
    [Column("user_id")]
    public long UserId { get; set; }

    [Column("enrolled_at")]
    public DateTime EnrolledAt { get; set; }

    [Column("completed_at")]
    public DateTime? CompletedAt { get; set; }

    [Column("is_completed")]
    public bool IsCompleted { get; set; } = false;

    [Column("completion_percentage")]
    public decimal CompletionPercentage { get; set; } = 0;

    [Column("total_time_spent_minutes")]
    public int TotalTimeSpentMinutes { get; set; } = 0;

    [Column("last_accessed_at")]
    public DateTime? LastAccessedAt { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}
