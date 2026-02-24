using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.MODELS.ProjectDTO;
public class ProjectDTO
{
    public string ProjectName { get; set; }
    public string ProjectVersion { get; set; }
    public bool isProjectCompleted { get; set; } = false;
}
