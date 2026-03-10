using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Common;

namespace TaskManagement.ENTITIES.Entities;

public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed
}
public class TaskEntity : BaseEntity
{
    //Bir görevin birden fazla kullanıcısı olabilir.
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } 
    //

    public string Name { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
}

