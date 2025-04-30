using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.User;
using Talabat.Application.Repository.Interfaces;
using Talabat.Infrastructure.Models;
using Talabat.Infrastructure.Presistance.Data;

namespace Talabat.Infrastructure.Presistance.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IMapper mapper) 
        {
            context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserResponseDTO> createUser(CreateUserDTO userDTO, IEnumerable<string>? roles)
        {
            var request = _mapper.Map<ApplicationUser>(userDTO);
            var user = await _userManager.CreateAsync(request, userDTO.Password);

            if (roles != null)
            {
                await _userManager.AddToRolesAsync(request, roles);
            }
            var response = _mapper.Map<UserResponseDTO>(user);
           
            return response;
        }



    }
}
