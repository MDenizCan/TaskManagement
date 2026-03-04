using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.TaskDTO;

namespace TaskManagement.BLL.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskEntity>> GetAllWithUsersAsync();
    Task<TaskEntity?> GetByIdWithUsersAsync(int taskId);
    Task<List<TaskDTO>> GetByProjectAsync(int projectId);

    Task<TaskDTO> AssignUserAsync(int taskId,int userId);
}
