using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillIT_Models.Constants;
using SkillIT_Models.Models;
using System;

namespace SkillItAPI.Controllers
{
    /// <summary>
    /// API controller for user management
    /// </summary>
    [Authorize]
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets all users (admin only)
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllUsers()
        {
            try
            {
                _logger.LogInformation("Getting all users");
                var data = _userService.GetAllUsers();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all users");
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Gets a specific user by ID
        /// </summary>
        /// <param name="id">The user ID</param>
        [HttpGet("{id}")]
        public IActionResult GetUser(long id)
        {
            try
            {
                _logger.LogInformation("Getting user {UserId}", id);
                var data = _userService.GetUser(id);
                
                if (data == null)
                {
                    return NotFound(new ResponseModel(false, AppConstants.Messages.UserNotFound));
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user {UserId}", id);
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Checks if an email exists in the system
        /// </summary>
        /// <param name="email">Email address to check</param>
        [AllowAnonymous]
        [HttpGet("check-email")]
        public IActionResult CheckEmailExistence([FromQuery] string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest(new ResponseModel(false, "Email is required"));
                }

                _logger.LogInformation("Checking email existence: {Email}", email);
                return Ok(_userService.CheckEmailExistence(email));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking email existence");
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Updates a user's profile picture
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="image">The image file</param>
        [HttpPost("{userId}/profile-picture")]
        public IActionResult UpdateProfilePicture([FromRoute] long userId, IFormFile image)
        {
            try
            {
                if (image == null)
                {
                    return BadRequest(new ResponseModel(false, "Image file is required"));
                }

                _logger.LogInformation("Updating profile picture for user {UserId}", userId);
                return Ok(_userService.UpdateProfilePicture(userId, image));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating profile picture for user {UserId}", userId);
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="userModel">User registration data</param>
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult AddUser([FromBody] UserModel userModel)
        {
            try
            {
                if (userModel == null)
                {
                    return BadRequest(new ResponseModel(false, "User data is required"));
                }

                _logger.LogInformation("Registering new user: {Email}", userModel.Email);
                var result = _userService.AddUser(userModel);
                
                if (result.Success)
                {
                    return CreatedAtAction(nameof(GetUser), new { id = userModel.UserId }, result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering user");
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Updates an existing user's information
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <param name="userModel">Updated user data</param>
        [HttpPut("{id}")]
        public IActionResult UpdateUser(long id, [FromBody] UserModel userModel)
        {
            try
            {
                if (userModel == null)
                {
                    return BadRequest(new ResponseModel(false, "User data is required"));
                }

                if (id != userModel.UserId)
                {
                    return BadRequest(new ResponseModel(false, "ID mismatch"));
                }

                _logger.LogInformation("Updating user {UserId}", id);
                return Ok(_userService.UpdateUser(userModel.UserId, userModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user {UserId}", id);
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }

        /// <summary>
        /// Deletes a user (admin only)
        /// </summary>
        /// <param name="id">The user ID</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteUser(long id)
        {
            try
            {
                _logger.LogInformation("Soft deleting user {UserId}", id);
                // Since we're using soft delete, we can update the User's IsDeleted flag
                // For now, return NotImplemented - implement soft delete logic in UserService if needed
                return StatusCode(501, new ResponseModel(false, "DeleteUser method not implemented in UserService"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user {UserId}", id);
                return StatusCode(500, new ResponseModel(false, AppConstants.Messages.Failed));
            }
        }
    }
}
