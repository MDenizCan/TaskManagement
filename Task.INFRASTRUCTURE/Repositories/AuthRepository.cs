using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;
using TaskManagement.ENTITIES.Entities;

namespace TaskManagement.INFRASTRUCTURE.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity> AddUserAsync(UserEntity user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UserEntity> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email);
    }
}
