using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.BLL.Interfaces;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.INFRASTRUCTURE.Repositories;

public class ProjectRepository(AppDbContext context) : GenericRepository<ProjectEntity>(context), IProjectRepository
{
    // Not: base class GenericRepository zaten _context tanimlıyor, yeniden tanımlamaya gerek yok.

    public async Task<List<ProjectEntity>> GetAllWithUsersAsync()
    {
        return await _context.Projects
            .Include(p => p.Users)
            .Include(p => p.Tasks)
            .ToListAsync();
    }

    public async Task<ProjectEntity?> GetByIdWithUsersAsync(int projectId)
    {
        return await _context.Projects
            .Include(p => p.Users)
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == projectId);
    }

    public async Task<List<UserDTO>> GetUsersAsync(int projectId)
    {
        var project = await _context.Projects
            .Include(p => p.Users)
            .FirstOrDefaultAsync(p => p.Id == projectId);
        if (project == null)
            throw new Exception("Project not found");
        return project.Users.Select(u => new UserDTO
        {
            Name = u.Name,
            Surname = u.Surname,
            Email = u.Email
        }).ToList();
    }

    public async Task<ProjectEntity> AddUserAsync(int projectId, int userId)
    {
        var project = await _context.Projects
            .Include(p => p.Users)
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == projectId);

        if (project == null)
        {
            throw new Exception("Project not found");
        }

        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        project.Users.Add(user);
        await _context.SaveChangesAsync();

        return project;
    }

    public async Task<ProjectEntity> RemoveUserAsync(int projectId, int userId)
    {
        var project = await _context.Projects
            .Include(p => p.Users)
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == projectId);

        if (project == null)
        {
            throw new Exception("Project not found");
        }

        var user = project.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            throw new Exception("User not found in this project");
        }

        project.Users.Remove(user);
        await _context.SaveChangesAsync();

        return project;
    }
}
