using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.DatabaseModels
{
    /// <summary>
    /// Tracks course view analytics
    /// </summary>
    [Table("course_views")]
    public class CourseView
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        [Column("view_id")]
        public int ViewId { get; set; }

        /// <summary>
        /// User who viewed the course
        /// </summary>
        [Column("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Course that was viewed
        /// </summary>
        [Column("course_id")]
        public int CourseId { get; set; }

        /// <summary>
        /// When the view occurred
        /// </summary>
        [Column("viewed_at")]
        public DateTime ViewedAt { get; set; }

        /// <summary>
        /// IP address of the viewer (optional)
        /// </summary>
        [Column("ip_address")]
        [MaxLength(45)]
        public string IpAddress { get; set; }

        /// <summary>
        /// User agent string (optional)
        /// </summary>
        [Column("user_agent")]
        [MaxLength(500)]
        public string UserAgent { get; set; }

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
