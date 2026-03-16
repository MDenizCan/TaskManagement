using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Interfaces;

public interface IAuthService
{
    Task<UserEntity> RegisterAsync(UserRegisterDto userRegisterDto, string password);
    Task<UserEntity> LoginAsync(string email, string password);
    Task<bool> UserExistsAsync(string email);
}
