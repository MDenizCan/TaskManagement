using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.MODELS.UpadteProjectDTO;
public class UpadteProjectDTO
{
    public string ProjectName { get; set; }
    public string ProjectVersion { get; set; }
    public bool isProjectCompleted { get; set; } = false;
}
