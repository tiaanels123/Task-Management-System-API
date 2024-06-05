using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Api.Models
{
    // Model for task entity
    public class Task
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Title { get; set; }
        
        public string? Description { get; set; }
        
        public string? Status { get; set; }

        [Required]
        public string? UserId { get; set; }

        public User? User { get; set; }
    }
}
