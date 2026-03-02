using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.MODELS.TaskDTO;

public class UpdateTaskDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
}
