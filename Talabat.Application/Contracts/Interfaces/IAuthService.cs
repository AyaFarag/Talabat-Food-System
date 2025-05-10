using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.Auth;

namespace Talabat.Application.Contracts.Interfaces
{
    public interface IAuthService
    {
        Task<UserResponse> RegisterAsync(UserRegisterRequest request);
        Task<UserResponse> LoginAsync(UserLoginRequest request);
        //Task<RevokeRefreshTokenResponse> RevokeRefreshToken(RefreshTokenRequest refreshTokenRemoveRequest);
        //Task<CurrentUserResponse> RefreshTokenAsync(RefreshTokenRequest request);
        //public string? GetUserId();
        //Task<CurrentUserResponse> GetCurrentUserAsync();
    }
}
