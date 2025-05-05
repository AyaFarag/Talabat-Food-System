using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.DTO.User;
using Talabat.Application.Repository.Interfaces;

namespace Talabat.Application.Contracts.Services
{
    public class UserService : IuserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository _userRepository, IMapper mapper) 
        {
            userRepository = _userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> CreateUser(CreateUserDTO userDTO)
        {
            var user = await userRepository.createUser(userDTO);

            var response = _mapper.Map<UserResponseDTO>(user);
            return response;

        }

        public async Task<UserResponseDTO> Edit(string id, UpdateUserDTO userDTO)
        {
            return await userRepository.updateUser(id, userDTO);
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllUsers()
        {
            return await userRepository.GetUsers();
        }

        public async Task<UserResponseDTO> AddUserRole(string id, string rolename)
        {
            return await userRepository.assignUserRole(id, rolename);
        }
        public async Task<bool> RemoveRoleFromUser(string id, string roleName)
        {
            return await userRepository.revokRole(id, roleName);
        }

        public async Task<bool> RemoveUser(string id)
        {
            return await userRepository.deleteUser(id);
        }

        public async Task<UserResponseDTO> userById(string id)
        {
            return await userRepository.getUserById(id);
        }
    }
}
