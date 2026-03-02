using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Services;

public class UserService : IUserService
{
    //getAllUsers
    //repodan userları çek
    public Task<List<UserDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    //getTasksByUserId
    //o user var mi
    //repodan o usera atanmış taskları çek
    public Task<UserDTO> GetByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    //CreateUser
    //repoya yonlendirme
    public Task<UserDTO> CreateAsync(CreateUserDTO createUserDto)
    {
        throw new NotImplementedException();
    }

    //updateUser
    //o user var mi
    //repoya yonlendirme
    public Task<UserDTO> UpdateAsync(int userId, UpdateUserDTO updateUserDto)
    {
        throw new NotImplementedException();
    }

    //deleteUser
    //o user var mi
    //repoya yonlendirme
    public Task<UserDTO> DeleteAsync(int userId)
    {
        throw new NotImplementedException();
    }

}
