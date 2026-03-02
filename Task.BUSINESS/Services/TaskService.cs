using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;
using TaskManagement.MODELS.TaskDTO;

namespace TaskManagement.BLL.Services;

public class TaskService : ITaskService
{
    //getAllTasks
    //repodan taskları çek
    public Task<List<TaskDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    //getTaskByProjectId
    //project var mi 
    //repodan o projectin tasklarını çek
    public Task<List<TaskDTO>> GetByProjectAsync(int projectId)
    {
        throw new NotImplementedException();
    }


    //getTaskById
    //o task var mi
    //repodan o taski çek
    public Task<TaskDTO> GetByIdAsync(int taskId)
    {
        throw new NotImplementedException();
    }

    //getUsersByTaskId
    //o task var mi
    //repodan o taska atanmış userları çek

    //CreateTaskbyProjectId
    //project kontrolu 
    //repoya yonlendirme
    public Task<TaskDTO> CreateAsync(int projectId, CreateTaskDTO createTaskDto)
    {
        throw new NotImplementedException();
    }

    //assignTaskToUser
    //o task var mi 
    //o user var mi
    //user var mi 
    //user o projectte var mi
    //eğer user o projectte yoksa useri project ekle ve taski usera ata
    //repoya yonlendirme
    public Task<TaskDTO> AssignUserAsync(int taskId, int userId)
    {
        throw new NotImplementedException();
    }

    //updateTask
    //o task var mi
    //repoya yonlendirme
    public Task<TaskDTO> UpdateAsync(int taskId, UpdateTaskDTO updateTaskDto)
    {
        throw new NotImplementedException();
    }

    //deleteTask
    //o task var mi
    //repoya yonlendirme
    public Task<TaskDTO> DeleteAsync(int taskId)
    {
        throw new NotImplementedException();
    }












}
