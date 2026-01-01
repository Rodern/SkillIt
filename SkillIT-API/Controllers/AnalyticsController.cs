using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SkillIT_API.Controllers
{
    /// <summary>
    /// API controller for analytics and reporting
    /// </summary>
    [Authorize]
    [Route("api/v1/analytics")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;
        private readonly ILogger<AnalyticsController> _logger;

        public AnalyticsController(
            IAnalyticsService analyticsService,
            ILogger<AnalyticsController> logger)
        {
            _analyticsService = analyticsService ?? throw new ArgumentNullException(nameof(analyticsService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Track a course view
        /// </summary>
        /// <param name="courseId">ID of the course being viewed</param>
        [HttpPost("track/course-view/{courseId}")]
        public async Task<IActionResult> TrackCourseView(int courseId)
        {
            try
            {
                var userIdClaim = User.FindFirst("UserId")?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                {
                    return Unauthorized(new { Message = "User not authenticated" });
                }

                var result = await _analyticsService.TrackCourseView(userId, courseId);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error tracking course view for CourseId={CourseId}", courseId);
                return StatusCode(500, new { Message = "Error tracking course view" });
            }
        }

        /// <summary>
        /// Get analytics for a specific course (Admin only)
        /// </summary>
        /// <param name="courseId">ID of the course</param>
        [HttpGet("course/{courseId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCourseAnalytics(int courseId)
        {
            try
            {
                var analytics = await _analyticsService.GetCourseAnalytics(courseId);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting course analytics for CourseId={CourseId}", courseId);
                return StatusCode(500, new { Message = "Error retrieving course analytics" });
            }
        }

        /// <summary>
        /// Get engagement metrics for the current user
        /// </summary>
        [HttpGet("user/engagement")]
        public async Task<IActionResult> GetUserEngagement()
        {
            try
            {
                var userIdClaim = User.FindFirst("UserId")?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                {
                    return Unauthorized(new { Message = "User not authenticated" });
                }

                var metrics = await _analyticsService.GetUserEngagementMetrics(userId);
                return Ok(metrics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user engagement metrics");
                return StatusCode(500, new { Message = "Error retrieving user engagement metrics" });
            }
        }

        /// <summary>
        /// Get trending courses
        /// </summary>
        /// <param name="topCount">Number of trending courses to return</param>
        /// <param name="daysBack">Number of days to look back for trends</param>
        [HttpGet("trending")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTrendingCourses(
            [FromQuery] int topCount = 10, 
            [FromQuery] int daysBack = 7)
        {
            try
            {
                var trending = await _analyticsService.GetTrendingCourses(topCount, daysBack);
                return Ok(trending);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting trending courses");
                return StatusCode(500, new { Message = "Error retrieving trending courses" });
            }
        }
    }
}
