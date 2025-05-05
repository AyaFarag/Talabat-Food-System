using AutoMapper;
using Azure.Core;
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
            var response = _mapper.Map<UserResponseDTO>(request);
            response.Roles = await _userManager.GetRolesAsync(request);
            return response;
        }
        public async Task<UserResponseDTO> assignUserRole(string id, string rolename)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return new UserResponseDTO() { };
            await _userManager.AddToRoleAsync(user, rolename);


            var roles = await _userManager.GetRolesAsync(user);
            var response = _mapper.Map<UserResponseDTO>(user);
            response.Roles = roles;
            return response;

        }
        public async Task<bool> revokRole(string id, string roleName)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;

        }
        public async Task<UserResponseDTO> updateUser(string id, UpdateUserDTO userDTO)
        {
            //var user = await _userManager.FindByIdAsync(id);

            
            var userData = _mapper.Map<ApplicationUser>(userDTO);
            
            await _userManager.UpdateAsync(userData);
            var response = _mapper.Map<UserResponseDTO>(userData);
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
            if (user == null) { throw new Exception(); }

            var response = _mapper.Map<UserResponseDTO>(user);
            response.Roles = await _userManager.GetRolesAsync(user);
            return response;

        }
        public async Task<IEnumerable<UserResponseDTO>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var response = _mapper.Map<IEnumerable<UserResponseDTO>>(users);
            
            return response;
        }

    }
}
