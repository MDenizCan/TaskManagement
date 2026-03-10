using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.TaskDTO;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Services;

public class TaskService : ITaskService
{
    private readonly IGenericRepository<TaskEntity> _genericTaskRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;
    private readonly IGenericRepository<UserEntity> _genericUserRepository;


    public TaskService
        (IGenericRepository<TaskEntity> GenericTaskRepository,
        IProjectRepository projectRepository,
        IMapper mapper,
        ITaskRepository taskRepository,
        IGenericRepository<UserEntity> genericUserRepository
        )
    {
        _genericTaskRepository = GenericTaskRepository;
        _mapper = mapper;
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
        _genericUserRepository = genericUserRepository;
    }

    //getAllTasks
    //repodan taskları çek
    public async Task<List<TaskDTO>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllWithUsersAsync();
        return tasks.Select(t => _mapper.Map<TaskDTO>(t)).ToList();
    }

    //getTaskByProjectId
    //project var mi 
    //repodan o projectin tasklarını çek
    public async Task<List<TaskDTO>> GetByProjectAsync(int projectId)
    {
        var project = await _projectRepository.GetByIdWithUsersAsync(projectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        // _taskRepository TaskEntity dönüyor, mapper ile DTO'ya çevir
        var tasks = await _taskRepository.GetByProjectAsync(projectId);
        return tasks.Select(t => _mapper.Map<TaskDTO>(t)).ToList();
    }


    //getTaskById
    //o task var mi
    //repodan o taski çek
    public async Task<TaskDTO> GetByIdAsync(int taskId)
    {
        var task = await _taskRepository.GetByIdWithUsersAsync(taskId);
        if (task == null)
        {
            throw new Exception("Task not found");
        }
        return _mapper.Map<TaskDTO>(task);
    }

    //CreateTaskbyProjectId
    //project kontrolu
    //repoya yonlendirme
    public async Task<TaskDTO> CreateAsync(int projectId, CreateTaskDTO dto)
    {
        var project = await _projectRepository.GetByIdWithUsersAsync(projectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        var task = _mapper.Map<TaskEntity>(dto);
        task.ProjectId = projectId;
        var createdTask = await _genericTaskRepository.CreateAsync(task);
        return _mapper.Map<TaskDTO>(createdTask);
    }

    //assignTaskToUser
    //o task var mi 
    //o user var mi
    //task'ın projesi var mı
    //user o projectte var mi
    //eğer user o projectte yoksa useri project ekle ve taski usera ata
    //repoya yonlendirme
    public async Task<TaskDTO> AssignUserAsync(int taskId, int userId)
    {
        var task = await _genericTaskRepository.GetByIdAsync(taskId);
        if (task == null)
        {
            throw new Exception("Task not found");
        }
        var user = await _genericUserRepository.GetByIdAsync(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        // Task'ın ait olduğu projeyi bul
        var project = await _projectRepository.GetByIdWithUsersAsync(task.ProjectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        // User projede yoksa projeye ekle
        if (!project.Users.Any(u => u.Id == userId))
        {
            project.Users.Add(user);
        }
        return _mapper.Map<TaskDTO>(await _taskRepository.AssignUserAsync(taskId, userId));
    }

    //updateTask
    //o task var mi
    //repoya yonlendirme
    public async Task<TaskDTO> UpdateAsync(int taskId, UpdateTaskDTO dto)
    {
        var task = await _genericTaskRepository.GetByIdAsync(taskId);
        if (task == null)
        {
            throw new Exception("Task not found");
        }
        _mapper.Map(dto, task);
        _genericTaskRepository.Update(task);
        await _genericTaskRepository.SaveChangesAsync();
        return _mapper.Map<TaskDTO>(task);
    }

    //deleteTask
    //o task var mi
    //repoya yonlendirme
    public async Task DeleteAsync(int taskId)
    {
        var task = await _genericTaskRepository.GetByIdAsync(taskId);
        if (task == null)
        {
            throw new Exception("Task not found");
        }
        _genericTaskRepository.Remove(task);
        await _genericTaskRepository.SaveChangesAsync();
    }
}
