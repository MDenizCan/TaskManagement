using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ENTITIES.Base;

namespace Task.ENTITIES.Entities;

public class UserEntity : BaseEntity
{
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public string UserRole { get; set; }
}

