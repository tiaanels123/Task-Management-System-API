using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Api.Models
{
    /// <summary>
    /// Model for task entity.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// The title of the task.
        /// </summary>
        [Required]
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
        [Required]
        public string? UserId { get; set; }

        /// <summary>
        /// The user assigned to the task.
        /// </summary>
        public User? User { get; set; }
    }
}
