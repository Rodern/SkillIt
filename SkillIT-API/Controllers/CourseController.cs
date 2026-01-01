using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SkillIT_API.Extensions;
using SkillIT_Models.Constants;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SkillIT_API.Controllers
{
    /// <summary>
    /// API controller for course management
    /// </summary>
    [Authorize]
    [Route("api/v1/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CourseController> _logger;

        public CourseController(
            ICourseService service, 
            IMemoryCache cache, 
            ILogger<CourseController> logger)
        {
            _courseService = service ?? throw new ArgumentNullException(nameof(service));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets all courses with pagination
        /// </summary>
        /// <param name="pageNumber">Page number (default: 1)</param>
        /// <param name="pageSize">Page size (default: 20)</param>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCourses(
            [FromQuery] int pageNumber = AppConstants.Pagination.DefaultPageNumber,
            [FromQuery] int pageSize = AppConstants.Pagination.DefaultPageSize)
        {
            try
            {
                _logger.LogInformation("Getting courses - Page: {PageNumber}, Size: {PageSize}", 
                    pageNumber, pageSize);

                var allCourses = _cache.GetOrCreate(
                    AppConstants.CacheKeys.AllCourses,
                    entry =>
                    {
                        entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                        return _courseService.GetCourses();
                    });

                var paginatedResult = allCourses.AsQueryable()
                    .ToPaginatedList(pageNumber, pageSize);

                return Ok(paginatedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting courses");
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Gets all course chapters with pagination
        /// </summary>
        [AllowAnonymous]
        [HttpGet("chapters")]
        public IActionResult GetAllChapters(
            [FromQuery] int pageNumber = AppConstants.Pagination.DefaultPageNumber,
            [FromQuery] int pageSize = AppConstants.Pagination.DefaultPageSize)
        {
            try
            {
                _logger.LogInformation("Getting all chapters - Page: {PageNumber}, Size: {PageSize}", 
                    pageNumber, pageSize);

                var chapters = _courseService.GetCourseChapters();
                var paginatedResult = chapters.AsQueryable()
                    .ToPaginatedList(pageNumber, pageSize);

                return Ok(paginatedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all chapters");
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Gets chapters for a specific course
        /// </summary>
        /// <param name="courseId">The course ID</param>
        [AllowAnonymous]
        [HttpGet("{courseId}/chapters")]
        public IActionResult GetCourseChapters(int courseId)
        {
            try
            {
                _logger.LogInformation("Getting chapters for course {CourseId}", courseId);

                var data = _courseService.GetCourseChapters(courseId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting chapters for course {CourseId}", courseId);
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Gets all lessons with pagination
        /// </summary>
        [AllowAnonymous]
        [HttpGet("lessons")]
        public IActionResult GetAllLessons(
            [FromQuery] int pageNumber = AppConstants.Pagination.DefaultPageNumber,
            [FromQuery] int pageSize = AppConstants.Pagination.DefaultPageSize)
        {
            try
            {
                _logger.LogInformation("Getting all lessons - Page: {PageNumber}, Size: {PageSize}", 
                    pageNumber, pageSize);

                var lessons = _courseService.GetCourseLessons();
                var paginatedResult = lessons.AsQueryable()
                    .ToPaginatedList(pageNumber, pageSize);

                return Ok(paginatedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all lessons");
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Gets a specific course by ID
        /// </summary>
        /// <param name="id">The course ID</param>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            try
            {
                _logger.LogInformation("Getting course {CourseId}", id);

                var course = _courseService.GetCourse(id);
                if (course == null)
                {
                    return NotFound(new ResponseModel(false, AppConstants.Messages.UserNotFound));
                }

                return Ok(course);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting course {CourseId}", id);
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Creates a new course
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "admin,creator")]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            try
            {
                _logger.LogInformation("Creating new course: {CourseName}", course?.Name);

                var result = _courseService.CreateCourse(course);
                
                if (result.Success)
                {
                    // Invalidate cache
                    _cache.Remove(AppConstants.CacheKeys.AllCourses);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating course");
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Updates an existing course
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,creator")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {
            try
            {
                _logger.LogInformation("Updating course {CourseId}", id);

                if (id != course.CourseId)
                {
                    return BadRequest(new ResponseModel(false, "ID mismatch"));
                }

                var result = _courseService.UpdateCourse(course);
                
                if (result.Success)
                {
                    // Invalidate cache
                    _cache.Remove(AppConstants.CacheKeys.AllCourses);
                    _cache.Remove($"{AppConstants.CacheKeys.CoursePrefix}{id}");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating course {CourseId}", id);
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Deletes a course
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteCourse(int id)
        {
            try
            {
                _logger.LogInformation("Deleting course {CourseId}", id);

                var result = _courseService.DeleteCourse(id);
                
                if (result.Success)
                {
                    // Invalidate cache
                    _cache.Remove(AppConstants.CacheKeys.AllCourses);
                    _cache.Remove($"{AppConstants.CacheKeys.CoursePrefix}{id}");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting course {CourseId}", id);
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }
    }
}
