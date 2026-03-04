using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.BLL.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UserService(IGenericRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    //getAllUsers
    //repodan userları çek
    public async Task<List<UserDTO>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDTO>>(users);
    }

    //getTasksByUserId
    //o user var mi
    //repodan o usera atanmış taskları çek
    public async Task<UserDTO> GetByIdAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        return _mapper.Map<UserDTO>(user);
    }

    //CreateUser
    //repoya yonlendirme
    public async Task<UserDTO> CreateAsync(CreateUserDTO dto)
    {
        var userEntity = _mapper.Map<UserEntity>(dto);
        await _userRepository.CreateAsync(userEntity);
        await _userRepository.SaveChangesAsync();

        return _mapper.Map<UserDTO>(userEntity);

    }

    //updateUser
    //o user var mi
    //repoya yonlendirme
    public async Task<UserDTO> UpdateAsync(int userId, UpdateUserDTO dto)
    {
        var student = await _userRepository.GetByIdAsync(userId);
        if (student == null)
        {
            throw new Exception("User not found");
        }
        _mapper.Map(dto, student);
        await _userRepository.SaveChangesAsync();   
        return _mapper.Map<UserDTO>(student);
    }

    //deleteUser
    //o user var mi
    //repoya yonlendirme
    public async Task DeleteAsync(int userId)
    {
        var student = await _userRepository.GetByIdAsync(userId);
        if (student == null)
        {
            throw new Exception("User not found");
        }
        _userRepository.Remove(student);
        await _userRepository.SaveChangesAsync();
    }

}
