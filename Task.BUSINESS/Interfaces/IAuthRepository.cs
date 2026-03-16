using System.Threading.Tasks;
using TaskManagement.ENTITIES.Entities;

namespace TaskManagement.BLL.Interfaces;

public interface IAuthRepository
{
    Task<UserEntity> GetUserByEmailAsync(string email);
    Task<UserEntity> AddUserAsync(UserEntity user);
    Task<bool> UserExistsAsync(string email);
}
