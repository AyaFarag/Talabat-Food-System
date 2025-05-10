using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.DTO.Auth;
using Talabat.Application.Repository.Interfaces;

namespace Talabat.Application.Contracts.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;
        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
              _tokenService = tokenService;
             _authRepository = authRepository;
        }
        public async Task<UserResponse> LoginAsync(UserLoginRequest request)
        {
            var user = await _authRepository.LoginAsync(request);
            var token = _tokenService.GenerateToken(user);
            user.AccessToken = await token;
            return user;
        }

        public async Task<UserResponse> RegisterAsync(UserRegisterRequest request)
        {
            var user = await _authRepository.RegisterAsync(request);
            var token = _tokenService.GenerateToken(user);
            user.AccessToken = await token;
            return user;
        }
    }
}
