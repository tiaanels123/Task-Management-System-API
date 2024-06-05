using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Api.Models
{
    /// <summary>
    /// Model for user login.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// The username of the user.
        /// </summary>
        [Required]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// The password of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
