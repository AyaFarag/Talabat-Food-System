using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IMapper mapper) 
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserResponseDTO> createUser(CreateUserDTO userDTO)
        {
            var request = _mapper.Map<ApplicationUser>(userDTO);
            var user = await _userManager.CreateAsync(request, userDTO.Password);

            if (userDTO.Roles != null)
            {
                await _userManager.AddToRolesAsync(request, userDTO.Roles);
            }
            var response = _mapper.Map<UserResponseDTO>(user);
           
            return response;
        }
        public async Task<bool> revokRole(string id, string roleName)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;

        }
        public async Task<UserResponseDTO> updateUser(string id, UpdateUserDTO userDTO)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (id != userDTO.Id) { throw new NotImplementedException(); }
            if (user == null) { throw new NotImplementedException(); }

            await _userManager.UpdateAsync(user);
            var response = _mapper.Map<UserResponseDTO>(user);
            return response;


        }
        public async Task<bool> deleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;

            await _userManager.DeleteAsync(user);
            return true;

        }
        public async Task<UserResponseDTO> getUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var response = _mapper.Map<UserResponseDTO>(user);
            return response;

        }
        public async Task<IEnumerable<UserResponseDTO>> GetUsers()
        {
            var users = await _userManager.Users
                        .Select(user => new UserResponseDTO()).ToListAsync();
            return users;
        }

    }
}
