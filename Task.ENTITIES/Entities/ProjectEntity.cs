using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Common;

namespace TaskManagement.ENTITIES.Entities;
public enum ProjectStatus
{
    NotStarted,
    InProgress,
    Completed
}

public class ProjectEntity : BaseEntity
{
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();

    public string Name { get; set; }
    public ProjectStatus Status { get; set; }
    public string Description { get; set; }

}

