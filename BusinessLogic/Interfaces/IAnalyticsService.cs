using BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface for analytics and reporting services
    /// </summary>
    public interface IAnalyticsService
    {
        /// <summary>
        /// Track a course view event
        /// </summary>
        Task<SkillIT_Models.Models.ResponseModel> TrackCourseView(int userId, int courseId);

        /// <summary>
        /// Get comprehensive analytics for a specific course
        /// </summary>
        Task<CourseAnalytics> GetCourseAnalytics(int courseId);

        /// <summary>
        /// Get user engagement metrics
        /// </summary>
        Task<UserEngagementMetrics> GetUserEngagementMetrics(int userId);

        /// <summary>
        /// Get trending courses based on recent activity
        /// </summary>
        Task<List<TrendingCourse>> GetTrendingCourses(int topCount = 10, int daysBack = 7);
    }

    /// <summary>
    /// Course analytics data model
    /// </summary>
    public class CourseAnalytics
    {
        public int CourseId { get; set; }
        public int TotalViews { get; set; }
        public int TotalEnrollments { get; set; }
        public int TotalCompletions { get; set; }
        public double CompletionRate { get; set; }
        public double AverageProgress { get; set; }
        public System.DateTime LastUpdated { get; set; }
    }

    /// <summary>
    /// User engagement metrics data model
    /// </summary>
    public class UserEngagementMetrics
    {
        public int UserId { get; set; }
        public int TotalCoursesEnrolled { get; set; }
        public int CoursesCompleted { get; set; }
        public int CoursesInProgress { get; set; }
        public int TotalAchievements { get; set; }
        public int TotalCertificates { get; set; }
        public double AverageCompletionRate { get; set; }
        public System.DateTime? LastActivityDate { get; set; }
    }

    /// <summary>
    /// Trending course data model
    /// </summary>
    public class TrendingCourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public int ViewCount { get; set; }
        public int UniqueViewers { get; set; }
    }
}
