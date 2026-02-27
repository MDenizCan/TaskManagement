using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.MODELS.ProjectDTO;
using Task.MODELS.UserDTO;

namespace Task.BLL.Interfaces;

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
    Task<ProjectDTO> CreateAsync(CreateProjectDto createProjectDto);

    //UpdateAsync(projectId, UpdateProjectDto)
    Task<ProjectDTO> UpdateAsync(int projectId, UpdateProjectDto updateProjectDto);

    //ChangeStatusAsync(projectId, ProjectStatus)

    //AddUserAsync(projectId, userId)

    //RemoveUserAsync(projectId, userId)

    //DeleteAsync(projectId)
}
