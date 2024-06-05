using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Api.Data;
using TaskModel = TaskManagementSystem.Api.Models.Task;

namespace TaskManagementSystem.Api.Repositories
{
    // Repository for handling task data operations
    public class TaskRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor for dependency injection
        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all tasks, including user details
        public virtual async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            return await _context.Tasks.Include(t => t.User).ToListAsync();
        }

        // Get task by ID, including user details
        public virtual async Task<TaskModel?> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
        }

        // Add a new task
        public virtual async Task AddTaskAsync(TaskModel task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        // Update an existing task
        public virtual async Task UpdateTaskAsync(TaskModel task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        // Delete a task
        public virtual async Task DeleteTaskAsync(TaskModel task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}