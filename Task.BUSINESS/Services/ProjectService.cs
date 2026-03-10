using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.CreateProjectDTO;
using TaskManagement.MODELS.ProjectDTO;
using TaskManagement.MODELS.TaskDTO;
using TaskManagement.MODELS.UpdateProjectDTO;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Services;

public class ProjectService : IProjectService
{
    private readonly IGenericRepository<TaskEntity> _genericTaskRepository;
    private readonly IGenericRepository<ProjectEntity> _genericProjectRepository;
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;
    private readonly IGenericRepository<UserEntity> _genericUserRepository;


    public ProjectService
        (IGenericRepository<TaskEntity> GenericTaskRepository,
        IGenericRepository<ProjectEntity> genericProjectRepository,
        IMapper mapper,
        IProjectRepository projectRepository,
        IGenericRepository<UserEntity> genericUserRepository
        )
    {
        _genericTaskRepository = GenericTaskRepository;
        _mapper = mapper;
        _projectRepository = projectRepository;
        _genericProjectRepository = genericProjectRepository;
        _genericUserRepository = genericUserRepository;
    }


    //getAllProjects
    //repodan projectleri çek
    //
    public async Task<List<ProjectDTO>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllWithUsersAsync();
        return projects.Select(p => _mapper.Map<ProjectDTO>(p)).ToList();
    }

    //getProjectById
    //o project var mi
    //repodan o projecti çek
    public async Task<ProjectDTO> GetByIdAsync(int projectId)
    {
        var project = await _projectRepository.GetByIdWithUsersAsync(projectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        return _mapper.Map<ProjectDTO>(project);
    }

    //getUsersByProjectId
    //o project var mi
    //repodan o projecte atanmış userları çek
    public async Task<List<UserDTO>> GetUsersAsync(int projectId)
    {
        var project = await _projectRepository.GetByIdWithUsersAsync(projectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        var users = project.Users;
        return users.Select(u => _mapper.Map<UserDTO>(u)).ToList();
    }

    //CreateProject
    //repoya yonlendirme
    public async Task<ProjectDTO> CreateAsync(CreateProjectDTO dto)
    {
        var projectEntity = _mapper.Map<ProjectEntity>(dto);
        var createdProject = await _genericProjectRepository.CreateAsync(projectEntity);
        return _mapper.Map<ProjectDTO>(createdProject);
    }

    //assignUserToProject
    //o project var mi
    //o user var mi
    //repoya yonlendirme
    public async Task<ProjectDTO> AddUserAsync(int projectId, int userId)
    {
        var project = await _projectRepository.GetByIdWithUsersAsync(projectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        var user = await _genericUserRepository.GetByIdAsync(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        if (project.Users.Any(u => u.Id == userId))
        {
            throw new Exception("User already assigned to project");
        }
        return _mapper.Map<ProjectDTO>(await _projectRepository.AddUserAsync(projectId, userId));
    }

    //updateProject
    //o project var mi
    //repoya yonlendirme
public async Task<ProjectDTO> UpdateAsync(int projectId, UpdateProjectDTO dto)
{
    var project = await _genericProjectRepository.GetByIdAsync(projectId);
    // project = veritabanından gelen mevcut proje nesnesi
    _mapper.Map(dto, project);
    // dto'nun property'lerini (Name, Status, Description) alıp
    // mevcut project nesnesine yazar
    // project nesnesi artık güncel
    _genericProjectRepository.Update(project);
    await _genericProjectRepository.SaveChangesAsync();
    return _mapper.Map<ProjectDTO>(project);
}

    //deleteProject
    //o project var mi
    //repoya yonlendirme
    public async Task DeleteAsync(int projectId)
    {
        var project = await _genericProjectRepository.GetByIdAsync(projectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        _genericProjectRepository.Remove(project);
        await _genericProjectRepository.SaveChangesAsync();
    }

    //remove user from project
    //o project var mi
    //o user var mi
    //o user o projectte atanmış mı
    //repoya yonlendirme
    public async Task<ProjectDTO> RemoveUserAsync(int projectId, int userId)
    {
        var project = await _projectRepository.GetByIdWithUsersAsync(projectId);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        var user = await _genericUserRepository.GetByIdAsync(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        if (!project.Users.Any(u => u.Id == userId))
        {
            throw new Exception("User not assigned to project");
        }
        return _mapper.Map<ProjectDTO>(await _projectRepository.RemoveUserAsync(projectId, userId));

    }


}
