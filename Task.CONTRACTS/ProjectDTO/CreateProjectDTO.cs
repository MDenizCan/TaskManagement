using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Entities;

namespace TaskManagement.MODELS.CreateProjectDTO;
public class CreateProjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;
    public string Description { get; set; }
}
