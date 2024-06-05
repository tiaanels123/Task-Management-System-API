using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TaskManagementSystem.Api.DTOs;
using TaskManagementSystem.Api.Repositories;
using TaskModel = TaskManagementSystem.Api.Models.Task;

namespace TaskManagementSystem.Api.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepository;
        private readonly ILogger<TaskService> _logger;

        // Constructor for dependency injection
        public TaskService(TaskRepository taskRepository, ILogger<TaskService> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        // Retrieves all tasks
        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            _logger.LogInformation("Retrieving all tasks.");
            try
            {
                var tasks = await _taskRepository.GetAllTasksAsync();
                return tasks.Select(task => new TaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                    UserId = task.UserId,
                    User = task.User != null ? new UserDto
                    {
                        Id = task.User.Id,
                        UserName = task.User.UserName,
                        Email = task.User.Email
                    } : null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all tasks.");
                throw;
            }
        }

        // Retrieves a task by ID
        public async Task<TaskDto?> GetTaskByIdAsync(int id)
        {
            _logger.LogInformation("Retrieving task with ID {Id}.", id);
            try
            {
                var task = await _taskRepository.GetTaskByIdAsync(id);
                if (task == null) return null;

                return new TaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                    UserId = task.UserId,
                    User = task.User != null ? new UserDto
                    {
                        Id = task.User.Id,
                        UserName = task.User.UserName,
                        Email = task.User.Email
                    } : null
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the task with ID {Id}.", id);
                throw;
            }
        }

        // Creates a new task
        public async Task<TaskDto> CreateTaskAsync(TaskModel task)
        {
            _logger.LogInformation("Creating a new task.");
            try
            {
                await _taskRepository.AddTaskAsync(task);
                _logger.LogInformation("Task created with ID {Id}.", task.Id);

                return new TaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                    UserId = task.UserId,
                    User = task.User != null ? new UserDto
                    {
                        Id = task.User.Id,
                        UserName = task.User.UserName,
                        Email = task.User.Email
                    } : null
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new task.");
                throw;
            }
        }

        // Updates an existing task
        public async Task UpdateTaskAsync(TaskModel task)
        {
            _logger.LogInformation("Updating task with ID {Id}.", task.Id);
            try
            {
                await _taskRepository.UpdateTaskAsync(task);
                _logger.LogInformation("Task with ID {Id} updated.", task.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the task with ID {Id}.", task.Id);
                throw;
            }
        }

        // Deletes a task by ID
        public async Task DeleteTaskAsync(int id)
        {
            _logger.LogInformation("Deleting task with ID {Id}.", id);
            try
            {
                var task = await _taskRepository.GetTaskByIdAsync(id);
                if (task != null)
                {
                    await _taskRepository.DeleteTaskAsync(task);
                    _logger.LogInformation("Task with ID {Id} deleted.", id);
                }
                else
                {
                    _logger.LogWarning("Task with ID {Id} not found.", id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the task with ID {Id}.", id);
                throw;
            }
        }
    }
}
