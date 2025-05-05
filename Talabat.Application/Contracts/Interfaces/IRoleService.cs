using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.Role;

namespace Talabat.Application.Contracts.Interfaces
{
    public interface IRoleService 
    {
        Task<RoleResponseDTO> createRole(CreateRoleDTO roleDto);
        Task<IEnumerable<RoleResponseDTO>> getRoles();

        Task<RoleResponseDTO> updateRole(string id, UpdateRoleDTO roleDTO);

        Task<bool> deleteRole(string id);
    }
}
