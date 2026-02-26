using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ENTITIES.Common;

namespace Task.ENTITIES.Entities;

public class ProjectEntity : BaseEntity
{
    public string ProjectName { get; set; }
    public string ProjectVersion { get; set; }
    public bool isProjectCompleted { get; set; } = false;
}

