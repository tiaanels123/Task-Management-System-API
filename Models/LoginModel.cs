using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Api.Models
{
    // Model for user login
    public class LoginModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
