using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ENTITIES.Entities;

namespace Task.MODELS.CreateProjectDTO;
public class CreateProjectDTO
{
    public string Name { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;
    public string Description { get; set; }
}
