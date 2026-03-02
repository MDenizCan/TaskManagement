using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;
using TaskManagement.MODELS.CreateProjectDTO;
using TaskManagement.MODELS.ProjectDTO;
using TaskManagement.MODELS.UpdateProjectDTO;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Services;

public class ProjectService : IProjectService
{
    //getAllProjects
    //repodan projectleri çek
    //
    public Task<List<ProjectDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    //getProjectById
    //o project var mi
    //repodan o projecti çek
    public Task<ProjectDTO> GetByIdAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    //getUsersByProjectId
    //o project var mi
    //repodan o projecte atanmış userları çek
    public Task<List<UserDTO>> GetUsersAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    //CreateProject
    //repoya yonlendirme
    public Task<ProjectDTO> CreateAsync(CreateProjectDTO createProjectDto)
    {
        throw new NotImplementedException();
    }

    //assignUserToProject
    //o project var mi
    //o user var mi
    //repoya yonlendirme
    public Task<UserDTO> AddUserAsync(int projectId, int userId)
    {
        throw new NotImplementedException();
    }

    //updateProject
    //o project var mi
    //repoya yonlendirme
    public Task<ProjectDTO> UpdateAsync(int projectId, UpdateProjectDTO updateProjectDto)
    {
        throw new NotImplementedException();
    }

    //deleteProject
    //o project var mi
    //repoya yonlendirme
    public Task<ProjectDTO> DeleteAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    //remove user from project
    //o project var mi
    //o user var mi
    //o user o projectte atanmış mı
    //repoya yonlendirme
    public Task<UserDTO> RemoveUserAsync(int projectId, int userId)
    {
        throw new NotImplementedException();
    }


}
