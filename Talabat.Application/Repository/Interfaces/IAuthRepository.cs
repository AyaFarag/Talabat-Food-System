using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.Auth;

namespace Talabat.Application.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserResponse> RegisterAsync(UserRegisterRequest requestDto);
        Task<UserResponse> LoginAsync(UserLoginRequest requestDto);
    }
}
