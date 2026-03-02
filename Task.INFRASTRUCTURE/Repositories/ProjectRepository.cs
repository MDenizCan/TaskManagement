using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.BLL.Interfaces;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.ProjectDTO;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.INFRASTRUCTURE.Repositories;

public class ProjectRepository(AppDbContext context) : GenericRepository<ProjectEntity>(context), IProjectRepository
{
    protected readonly AppDbContext _context = context;

    public async Task<List<UserEntity>> GetUsersAsync(int projectId)
    {
        var project = await _context.Projects
            .Include(p => p.Users)
            .FirstOrDefaultAsync(p => p.Id == projectId);

        if (project == null)
        {
            throw new Exception("Project not found");
        }
    }
    public async Task<ProjectDTO> AddUserAsync(int projectId, int userId)
    {
        var project = _context.Projects.Find(projectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        var user = await _context.Users.FindAsync(userId);  
        if (user == null)
        {
            throw new Exception("User not found");
        }
    }

    public async Task<ProjectDTO> RemoveUserAsync(int projectId, int userId)
    {
        var project = await _context.Projects.FindAsync(projectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }

        // The following assumes that ProjectEntity has a navigation property like ICollection<UserEntity> Users.
        // If it does not, you must add it to ProjectEntity and configure it in your DbContext.

        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        // Uncomment and use the following line ONLY if ProjectEntity has a Users collection:
        // project.Users.Remove(user);

        // await _context.SaveChangesAsync();

        // Map project to ProjectDTO as needed. Placeholder below:
        // return new ProjectDTO { ... };

        throw new NotImplementedException("ProjectEntity does not have a Users collection. Add a navigation property ICollection<UserEntity> Users to ProjectEntity to enable this functionality.");
    }
}
