using System;
using System.Collections.Generic; //ICollection
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Common;

namespace TaskManagement.ENTITIES.Entities;
public enum ProjectStatus
{
    NotStarted,
    InProgress,
    Completed
}

public class ProjectEntity : BaseEntity
{
    //Entity'lerinde ICollection şunu yapar: "Bu nesne birden fazla başka nesneye bağlanabilir"
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>(); //Bir projenin birden fazla kullanıcısı olabilir.
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>(); //Bir projenin birden fazla görevi olabilir.

    public string Name { get; set; }
    public ProjectStatus Status { get; set; }
    public string Description { get; set; }

}

