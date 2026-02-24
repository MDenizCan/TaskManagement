using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.ENTITIES.Project;

internal class ProjectEntity
{
    public string ProjectName { get; set; }
    public string ProjectVersion { get; set; }
    public bool isProjectCompleted { get; set; } = false;
}

