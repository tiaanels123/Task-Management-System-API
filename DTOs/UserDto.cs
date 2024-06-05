namespace TaskManagementSystem.Api.DTOs
{
    // DTO for user data transfer
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    // DTO for updating user data transfer
    public class UserUpdateDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
