using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Entities;

namespace TaskManagement.MODELS.TaskDTO;

public class TaskDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskManagement.ENTITIES.Entities.TaskStatus Status { get; set; }
    public List<int> UserIds { get; set; } = new List<int>();
}