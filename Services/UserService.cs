using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TaskManagementSystem.Api.DTOs;
using TaskManagementSystem.Api.Models;

namespace TaskManagementSystem.Api.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserService> _logger;

        // Constructor for dependency injection
        public UserService(UserManager<User> userManager, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        // Retrieves user information by user ID
        public async Task<UserDto?> GetUserInfoAsync(string userId)
        {
            _logger.LogInformation("Retrieving user info for user ID {UserId}.", userId);
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogWarning("User with ID {UserId} not found.", userId);
                    return null;
                }

                return new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user info for user ID {UserId}.", userId);
                throw;
            }
        }

        // Updates user information by user ID
        public async Task<bool> UpdateUserInfoAsync(string userId, UserDto userDto)
        {
            _logger.LogInformation("Updating user info for user ID {UserId}.", userId);
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogWarning("User with ID {UserId} not found.", userId);
                    return false;
                }

                user.UserName = userDto.UserName;
                user.Email = userDto.Email;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to update user info for user ID {UserId}.", userId);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating user info for user ID {UserId}.", userId);
                throw;
            }
        }
    }
}
