using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.ProjectDTO;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Interfaces;

public interface IProjectRepository
{
    Task<List<ProjectEntity>> GetAllWithUsersAsync();
    Task<ProjectEntity?> GetByIdWithUsersAsync(int projectId);

    Task<List<UserDTO>> GetUsersAsync(int projectId);

    Task<ProjectDTO> AddUserAsync(int projectId,int userId);

    Task<ProjectDTO> RemoveUserAsync(int projectId, int userId);
}

