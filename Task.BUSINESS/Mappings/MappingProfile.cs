using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.CreateProjectDTO;
using TaskManagement.MODELS.ProjectDTO;
using TaskManagement.MODELS.TaskDTO;
using TaskManagement.MODELS.UpdateProjectDTO;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Mappings;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<ProjectEntity, ProjectDTO>();
        CreateMap<CreateProjectDTO, ProjectEntity>();
        CreateMap<UpdateProjectDTO, ProjectEntity>();

        CreateMap<UserEntity, UserDTO>();
        CreateMap<CreateUserDTO, UserEntity>();
        CreateMap<UpdateUserDTO, UserEntity>();

        CreateMap<TaskEntity, TaskDTO>();
        CreateMap<CreateTaskDTO, TaskEntity>();
        CreateMap<UpdateTaskDTO, TaskEntity>();
    }
}
