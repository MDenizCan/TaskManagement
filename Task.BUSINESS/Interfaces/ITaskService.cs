using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.MODELS.TaskDTO;

namespace TaskManagement.BLL.Interfaces;

public interface ITaskService
{
    //GetByIdAsync(taskId)
    Task<TaskDTO> GetByIdAsync(int taskId);

    //GetByProjectAsync(projectId)
    Task<List<TaskDTO>> GetByProjectAsync(int projectId);

    //CreateAsync(projectId, CreateTaskDto)
    Task<TaskDTO> CreateAsync(int projectId, CreateTaskDTO createTaskDto);

    //UpdateAsync(taskId, UpdateTaskDto)
    Task<TaskDTO> UpdateAsync(int taskId, UpdateTaskDTO updateTaskDto);

    //AssignUserAsync(taskId, userId)
    Task<TaskDTO> AssignUserAsync(int taskId, int userId);

    //DeleteAsync(taskId)
    Task<TaskDTO> DeleteAsync(int taskId);

    //GetAllAsync()
    Task<List<TaskDTO>> GetAllAsync();
}
