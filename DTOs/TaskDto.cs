namespace TaskManagementSystem.Api.DTOs
{
    // DTO for task data transfer
    public class TaskDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? UserId { get; set; }
        public UserDto? User { get; set; }
    }
}
