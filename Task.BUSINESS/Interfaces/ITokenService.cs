using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Entities;

namespace TaskManagement.BLL.Interfaces;

public interface ITokenService
{
    string CreateToken(UserEntity user);
}
