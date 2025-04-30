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
        Task<UserResponseDTO> createUser(CreateUserDTO userDTO, IEnumerable<string>? roles = null);
    }
}
