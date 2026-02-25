using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ENTITIES.Base;

namespace Task.ENTITIES.Entities;

public class TaskEntity : BaseEntity
{
    public string TaskName { get; set; }    
    public string TaskType { get; set; }
    public bool IsTaskCompleted { get; set; }
}

