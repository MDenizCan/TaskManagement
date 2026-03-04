using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Interfaces;

public interface IUserService
{
    //dto dosyalari eklenecek
    //GetAllAsync()
    Task<List<UserDTO>> GetAllAsync();

    //GetByIdAsync(userId)
    Task<UserDTO> GetByIdAsync(int userId);

    //CreateAsync(CreateUserDto)
    Task<UserDTO> CreateAsync(CreateUserDTO createUserDto);

    //UpdateAsync(userId, UpdateUserDto)
    Task<UserDTO> UpdateAsync(int userId, UpdateUserDTO updateUserDto);

    //DeleteAsync(userId)
    Task DeleteAsync(int userId);
}
