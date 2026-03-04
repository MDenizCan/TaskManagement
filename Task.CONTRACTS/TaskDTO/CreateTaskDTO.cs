using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Entities;

namespace TaskManagement.MODELS.TaskDTO;

public class CreateTaskDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskManagement.ENTITIES.Entities.TaskStatus Status { get; set; }
}
