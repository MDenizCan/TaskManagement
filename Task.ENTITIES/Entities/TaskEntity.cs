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
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
}

