using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.DTO.Role;
using Talabat.Application.Repository.Interfaces;

namespace Talabat.Application.Contracts.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public RoleService(IMapper mapper, IRoleRepository roleRepository) 
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        public async Task<RoleResponseDTO> createRole(CreateRoleDTO roleDto)
        {
            return await _roleRepository.createRole(roleDto);
        }

        public async Task<IEnumerable<RoleResponseDTO>> getRoles()
        {
            return await _roleRepository.getRoles();
        }

        public async Task<RoleResponseDTO> updateRole(string id, UpdateRoleDTO roleDTO)
        {
            return await _roleRepository.updateRole(id, roleDTO);
        }

        public async Task<bool> deleteRole(string id)
        {
            return await _roleRepository.deleteRole(id);
        }

      
    }
}
