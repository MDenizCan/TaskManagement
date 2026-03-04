using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.BLL.Interfaces;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.TaskDTO;

namespace TaskManagement.INFRASTRUCTURE.Repositories;

public class TaskRepository(AppDbContext context) : GenericRepository<TaskEntity>(context), ITaskRepository
{
    public async Task<List<TaskEntity>> GetAllWithUsersAsync()
    {
        return await _context.Tasks
            .Include(t => t.Users)
            .ToListAsync();
    }

    public async Task<TaskEntity?> GetByIdWithUsersAsync(int taskId)
    {
        return await _context.Tasks
            .Include(t => t.Users)
            .FirstOrDefaultAsync(t => t.Id == taskId);
    }

    public async Task<List<TaskDTO>> GetByProjectAsync(int projectId)
    {
        var tasks = await _context.Tasks
            .Include(t => t.Users)
            .Where(t => t.ProjectId == projectId)
            .ToListAsync();

        return tasks.Select(t => new TaskDTO
        {
            Name = t.Name,
            Description = t.Description,
            Status = t.Status,
            UserIds = t.Users.Select(u => u.Id).ToList()
        }).ToList();
    }

    public async Task<TaskDTO> AssignUserAsync(int taskId, int userId)
    {
        var task = await _context.Tasks
            .Include(t => t.Users)
            .FirstOrDefaultAsync(t => t.Id == taskId);
        if (task == null)
        {
            throw new Exception("Task not found");
        }

        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        task.Users.Add(user);
        await _context.SaveChangesAsync();

        return new TaskDTO
        {
            Name = task.Name,
            Description = task.Description,
            Status = task.Status,
            UserIds = task.Users.Select(u => u.Id).ToList()
        };
    }
}
