using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.MODELS.TaskDTO;

public class TaskDTO
{
    public string TaskName { get; set; }
    public string TaskType { get; set; }
    public bool IsTaskCompleted { get; set; }
}
