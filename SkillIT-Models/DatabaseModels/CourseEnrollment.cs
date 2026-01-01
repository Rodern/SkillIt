using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.DatabaseModels
{
    /// <summary>
    /// Represents a course enrollment with completion tracking
    /// </summary>
    [Table("course_enrollments")]
    public class CourseEnrollment
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        [Column("enrollment_id")]
        public int EnrollmentId { get; set; }

        /// <summary>
        /// User who enrolled
        /// </summary>
        [Column("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Enrolled course
        /// </summary>
        [Column("course_id")]
        public int CourseId { get; set; }

        /// <summary>
        /// When the user enrolled
        /// </summary>
        [Column("enrolled_at")]
        public DateTime EnrolledAt { get; set; }

        /// <summary>
        /// Completion percentage (0-100)
        /// </summary>
        [Column("completion_percentage")]
        public int CompletionPercentage { get; set; }

        /// <summary>
        /// When the user last accessed this course
        /// </summary>
        [Column("last_accessed")]
        public DateTime? LastAccessed { get; set; }

        /// <summary>
        /// Navigation property to User
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        /// <summary>
        /// Navigation property to Course
        /// </summary>
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
