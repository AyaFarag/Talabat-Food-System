using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.Role;
using Talabat.Application.DTO.User;
using Talabat.Application.Repository.Interfaces;
using Talabat.Infrastructure.Models;
using Talabat.Infrastructure.Presistance.Data;

namespace Talabat.Infrastructure.Presistance.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public RoleRepository(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _context = context;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<RoleResponseDTO> createRole(CreateRoleDTO roleDto)
        {
            var role = _mapper.Map<IdentityRole>(roleDto);
            await _roleManager.CreateAsync(role);
            var response = _mapper.Map<RoleResponseDTO>(role);
            return response;
        }

     

        public async Task<IEnumerable<RoleResponseDTO>> getRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var response = _mapper.Map<IEnumerable<RoleResponseDTO>>(roles);
            return response;
        }

        public async Task<RoleResponseDTO> updateRole(string id, UpdateRoleDTO roleDTO)
        {
            if (id != roleDTO.Id) {
                throw new Exception();
            }
            var roleModel = _mapper.Map<IdentityRole>(roleDTO);
            
            var role = await _roleManager.UpdateAsync(roleModel);
            
            var response = _mapper.Map<RoleResponseDTO>(roleModel);
            return response;
        }

        public async Task<bool> deleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role == null) return false;  
            var isdeleted = await _roleManager.DeleteAsync(role);
            return isdeleted.Succeeded;
        }

        //public async Task<RoleResponseDTO> UpdateRole(string id, UpdateRoleDTO roleDTO)
        //{
        //    if (id != roleDTO.Id)
        //    {
        //        return null;
        //    }
        //    var roleModel = _mapper.Map<IdentityRole>(roleDTO);
        //    var result = await _roleManager.UpdateAsync(roleModel);
        //    if (!result.Succeeded)
        //    {
        //        return null;
        //    }
        //    var response = _mapper.Map<RoleResponseDTO>(roleModel);
        //    return response;
        //}


    }
}
