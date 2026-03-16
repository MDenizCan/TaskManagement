using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<UserEntity> LoginAsync(string email, string password)
    {
        var user = await _authRepository.GetUserByEmailAsync(email);

        if (user == null)
            return null;

        if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            return null;

        return user;
    }

    public async Task<UserEntity> RegisterAsync(UserRegisterDto userRegisterDto, string password)
    {
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = new UserEntity
        {
            Name = userRegisterDto.Name,
            Surname = userRegisterDto.Surname,
            Email = userRegisterDto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Role = "User" // Default role
        };

        await _authRepository.AddUserAsync(user);

        return user;
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _authRepository.UserExistsAsync(email);
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i]) return false;
            }
        }
        return true;
    }
}
