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
        Task<UserResponseDTO> CreateUser(CreateUserDTO userDTO, IEnumerable<string>? roles = null);

    }
}
