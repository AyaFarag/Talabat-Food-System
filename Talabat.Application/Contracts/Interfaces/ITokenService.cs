using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.Auth;
using Talabat.Application.DTO.User;

namespace Talabat.Application.Contracts.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserResponse user);
        string GenerateRefreshToken();
    }
}
