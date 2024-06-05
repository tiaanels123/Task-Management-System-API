namespace TaskManagementSystem.Api.DTOs
{
    /// <summary>
    /// DTO for user data transfer.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// The email of the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO for updating user data transfer.
    /// </summary>
    public class UserUpdateDto
    {
        /// <summary>
        /// The new username of the user.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// The new email of the user.
        /// </summary>
        public string? Email { get; set; }
    }
}
