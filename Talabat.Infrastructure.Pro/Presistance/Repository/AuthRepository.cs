using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.Auth;
using Talabat.Application.Repository.Interfaces;
using Talabat.Infrastructure.Models;
using Talabat.Infrastructure.Presistance.Data;

namespace Talabat.Infrastructure.Presistance.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AuthRepository(UserManager<ApplicationUser> userManager,
          IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserResponse> RegisterAsync(UserRegisterRequest requestDto)
        {
            var userMapped = _mapper.Map<ApplicationUser>(requestDto);
            var result = await _userManager.CreateAsync(userMapped , requestDto.Password);
            var response = _mapper.Map<UserResponse>(userMapped);
            return response;
        }
        public async Task<UserResponse> LoginAsync(UserLoginRequest requestDto)
        {
            var user = await _userManager.FindByEmailAsync(requestDto.Email);
            var check = await _userManager.CheckPasswordAsync(user, requestDto.Password);
            if (user == null || !check) { throw new Exception(); }
            var response = _mapper.Map<UserResponse>(user);
            return response;
        }

        
    }
}
