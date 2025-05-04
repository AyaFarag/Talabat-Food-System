using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.User;

namespace Talabat.Application.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserResponseDTO> createUser(CreateUserDTO userDTO);
        Task<UserResponseDTO> updateUser(string id , UpdateUserDTO userDTO);
        Task<bool> deleteUser(string id);
        Task<IEnumerable<UserResponseDTO>> GetUsers();
        Task<UserResponseDTO> getUserById(string id);
        Task<bool> revokRole(string id ,string roleName);

    }
}
