using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Api.Models;

namespace TaskManagementSystem.Api.Data
{
    // Application database context for Entity Framework
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        // Constructor for dependency injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for tasks
        public DbSet<TaskManagementSystem.Api.Models.Task> Tasks { get; set; } = null!;
    }
}
