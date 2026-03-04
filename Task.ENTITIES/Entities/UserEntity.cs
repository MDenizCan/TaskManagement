using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Common;

namespace TaskManagement.ENTITIES.Entities;

public class UserEntity : BaseEntity
{
    public ICollection<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

