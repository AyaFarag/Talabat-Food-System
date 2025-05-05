using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.User;

namespace Talabat.Application.Contracts.Interfaces
{
    public interface IuserService
    {
        Task<UserResponseDTO> CreateUser(CreateUserDTO userDTO);
        Task<UserResponseDTO> Edit(string id, UpdateUserDTO userDTO);
        Task<bool> RemoveUser(string id);
        Task<IEnumerable<UserResponseDTO>> GetAllUsers();
        Task<UserResponseDTO> userById(string id);
        Task<UserResponseDTO> AddUserRole(string id, string rolename);
        Task<bool> RemoveRoleFromUser(string id, string roleName);

    }
}
