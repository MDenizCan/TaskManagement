using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ENTITIES.Common;

namespace Task.ENTITIES.Entities;
public enum ProjectStatus
{
    NotStarted,
    InProgress,
    Completed
}

public class ProjectEntity : BaseEntity
{
    public string Name { get; set; }
    public ProjectStatus Status { get; set; }
    public string Description { get; set; }

}

