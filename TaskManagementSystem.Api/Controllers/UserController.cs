using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManagementSystem.Api.DTOs;
using TaskManagementSystem.Api.Models;
using TaskManagementSystem.Api.Services;

namespace TaskManagementSystem.Api.Controllers
{
    /// <summary>
    /// Handles operations related to users.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(UserService userService, UserManager<User> userManager, ILogger<UsersController> logger)
        {
            _userService = userService;
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint to get the authenticated user's info.
        /// </summary>
        [HttpGet("me")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("User ID not found in token.");
                return Unauthorized();
            }

            var userInfo = await _userService.GetUserInfoAsync(userId);
            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        /// <summary>
        /// Endpoint to update the authenticated user's info.
        /// </summary>
        /// <param name="userDto">The user data transfer object.</param>
        [HttpPut("me")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserDto userDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("User ID not found in token.");
                return Unauthorized();
            }

            var success = await _userService.UpdateUserInfoAsync(userId, userDto);
            if (!success)
            {
                return BadRequest("Failed to update user info.");
            }

            return NoContent();
        }
    }
}