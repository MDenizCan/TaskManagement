using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ENTITIES.Entities;

namespace Task.MODELS.ProjectDTO;
public class ProjectDTO
{
    public string Name { get; set; }
    public ProjectStatus Status { get; set; }
    public string Description { get; set; }
}
