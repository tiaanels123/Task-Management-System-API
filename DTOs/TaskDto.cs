namespace TaskManagementSystem.Api.DTOs
{
    /// <summary>
    /// DTO for task data transfer.
    /// </summary>
    public class TaskDto
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the task.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// A brief description of the task.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The current status of the task.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// The ID of the user assigned to the task.
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// The user assigned to the task.
        /// </summary>
        public UserDto? User { get; set; }
    }
}
