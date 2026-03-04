using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.MODELS.ProjectDTO;
using TaskManagement.MODELS.UserDTO;
using TaskManagement.MODELS.UpdateProjectDTO;
using TaskManagement.MODELS.CreateProjectDTO;


namespace TaskManagement.BLL.Interfaces;

public interface IProjectService
{
    //<List> birden fazla proje döndüreceği için.
    //Task<T> ne demek: async programlama ile alakali bu yapı, asenkron işlemler için kullanılır.
    //Task<T> bir işlemin sonucunu temsil eder ve T, işlemin sonucunun türünü belirtir.
    //Örneğin, Task<List<ProjectDTO>> ifadesi, bir asenkron işlemin sonucunda bir List<ProjectDTO> döndüreceğini ifade eder.
    //Bu sayede, işlemi başlattığınızda programınız diğer görevleri yerine getirmeye devam edebilir ve işlem tamamlandığında sonucu alabilirsiniz.
    Task<List<ProjectDTO>> GetAllAsync();

    //GetByIdAsync(projectId)
    Task<ProjectDTO> GetByIdAsync(int projectId);

    //GetUsersAsync(projectId)
    Task<List<UserDTO>> GetUsersAsync(int projectId);

    //CreateAsync(CreateProjectDto)
    Task<ProjectDTO> CreateAsync(CreateProjectDTO dto);
    //onceden->Task<CreateProjectDTO> CreateAsync(CreateProjectDTO createProjectDto);
    //UpdateAsync(projectId, UpdateProjectDto)
    Task<ProjectDTO> UpdateAsync(int projectId, UpdateProjectDTO dto);
    //onceden->Task<UpdateProjectDTO> UpdateAsync(int projectId, UpdateProjectDTO
    
    //AddUserAsync(projectId, userId)
    Task<ProjectDTO> AddUserAsync(int projectId, int userId);

    //RemoveUserAsync(projectId, userId)
    Task<ProjectDTO> RemoveUserAsync(int projectId, int userId);

    //DeleteAsync(projectId)
    Task DeleteAsync(int projectId);
}
