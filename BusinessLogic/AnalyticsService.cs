using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillIT_Models;
using SkillIT_Models.Data;
using SkillIT_Models.Entities.Analytics;
using SkillIT_Models.Entities.Courses;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Service for tracking and analyzing user engagement and course analytics
    /// </summary>
    public class AnalyticsService : IAnalyticsService
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly ILogger<AnalyticsService> _logger;

        public AnalyticsService(
            ApplicationDbContext dbContext, 
            ILogger<AnalyticsService>? logger = null)
        {
            _databaseContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger;
        }

        /// <summary>
        /// Track a course view event
        /// </summary>
        public async Task<ResponseModel> TrackCourseView(int userId, int courseId)
        {
            try
            {
                _logger?.LogInformation("Tracking course view: UserId={UserId}, CourseId={CourseId}", 
                    userId, courseId);

                var courseView = new CourseView
                {
                    UserId = userId,
                    CourseId = courseId,
                    ViewedAt = DateTime.UtcNow,
                    IpAddress = null, // Can be populated from HttpContext
                    UserAgent = null  // Can be populated from HttpContext
                };

                await _databaseContext.CourseViews.AddAsync(courseView);
                await _databaseContext.SaveChangesAsync();

                return new ResponseModel(true, "Course view tracked successfully");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error tracking course view for UserId={UserId}, CourseId={CourseId}", 
                    userId, courseId);
                return new ResponseModel(false, $"Failed to track course view: {ex.Message}");
            }
        }

        /// <summary>
        /// Get course analytics summary
        /// </summary>
        public async Task<CourseAnalytics> GetCourseAnalytics(int courseId)
        {
            try
            {
                _logger?.LogInformation("Getting analytics for CourseId={CourseId}", courseId);

                var views = await _databaseContext.CourseViews
                    .Where(cv => cv.CourseId == courseId)
                    .AsNoTracking()
                    .CountAsync();

                var enrollments = await _databaseContext.Enrollments
                    .Where(ce => ce.CourseId == courseId)
                    .AsNoTracking()
                    .CountAsync();

                var completions = await _databaseContext.Enrollments
                    .Where(ce => ce.CourseId == courseId && ce.CompletionPercentage >= 100)
                    .AsNoTracking()
                    .CountAsync();

                var averageProgress = await _databaseContext.Enrollments
                    .Where(ce => ce.CourseId == courseId)
                    .AsNoTracking()
                    .AverageAsync(ce => (double?)ce.CompletionPercentage) ?? 0;

                return new CourseAnalytics
                {
                    CourseId = courseId,
                    TotalViews = views,
                    TotalEnrollments = enrollments,
                    TotalCompletions = completions,
                    CompletionRate = enrollments > 0 ? (double)completions / enrollments * 100 : 0,
                    AverageProgress = averageProgress,
                    LastUpdated = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error getting analytics for CourseId={CourseId}", courseId);
                throw;
            }
        }

        /// <summary>
        /// Get user engagement metrics
        /// </summary>
        public async Task<UserEngagementMetrics> GetUserEngagementMetrics(int userId)
        {
            try
            {
                _logger?.LogInformation("Getting engagement metrics for UserId={UserId}", userId);

                var enrollments = await _databaseContext.Enrollments
                    .Where(ce => ce.UserId == userId)
                    .AsNoTracking()
                    .ToListAsync();

                var completedCourses = enrollments.Count(e => e.CompletionPercentage >= 100);
                var inProgressCourses = enrollments.Count(e => e.CompletionPercentage > 0 && e.CompletionPercentage < 100);

                var achievements = await _databaseContext.UserAchievements
                    .Where(ua => ua.UserId == userId)
                    .AsNoTracking()
                    .CountAsync();

                var certificates = await _databaseContext.UserCertificates
                    .Where(uc => uc.UserId == userId)
                    .AsNoTracking()
                    .CountAsync();

                return new UserEngagementMetrics
                {
                    UserId = userId,
                    TotalCoursesEnrolled = enrollments.Count,
                    CoursesCompleted = completedCourses,
                    CoursesInProgress = inProgressCourses,
                    TotalAchievements = achievements,
                    TotalCertificates = certificates,
                    AverageCompletionRate = enrollments.Any() 
                        ? (double)enrollments.Average(e => e.CompletionPercentage) 
                        : 0,
                    LastActivityDate = enrollments.Any() 
                        ? enrollments.Max(e => e.LastAccessed ?? e.EnrolledAt) 
                        : null
                };
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error getting engagement metrics for UserId={UserId}", userId);
                throw;
            }
        }

        /// <summary>
        /// Get trending courses based on recent views and enrollments
        /// </summary>
        public async Task<List<TrendingCourse>> GetTrendingCourses(int topCount = 10, int daysBack = 7)
        {
            try
            {
                _logger?.LogInformation("Getting top {TopCount} trending courses for last {DaysBack} days", 
                    topCount, daysBack);

                var sinceDate = DateTime.UtcNow.AddDays(-daysBack);

                var trendingCourses = await _databaseContext.CourseViews
                    .Where(cv => cv.ViewedAt >= sinceDate)
                    .GroupBy(cv => cv.CourseId)
                    .Select(g => new TrendingCourse
                    {
                        CourseId = (int)g.Key,
                        ViewCount = g.Count(),
                        UniqueViewers = g.Select(cv => cv.UserId).Distinct().Count()
                    })
                    .OrderByDescending(tc => tc.ViewCount)
                    .Take(topCount)
                    .AsNoTracking()
                    .ToListAsync();

                // Enrich with course details
                foreach (var trending in trendingCourses)
                {
                    var course = await _databaseContext.Courses
                        .Where(c => c.Id == trending.CourseId)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    if (course != null)
                    {
                        trending.CourseName = course.Name;
                        trending.ThumbnailUrl = course.CoverImage;
                    }
                }

                return trendingCourses;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error getting trending courses");
                throw;
            }
        }
    }
}
