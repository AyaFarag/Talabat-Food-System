using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.Permission;

namespace Talabat.Application.Repository.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IList<PermissionResponseDTO>> getRolesClaims(string id);
        Task<IList<PermissionResponseDTO>> getUserClaims(string id);

        Task<string> createUserClaim(string id, string claimValue);
        Task<string> createRoleClaim(string id, string claimValue);

        Task<bool> revokeUserClaim(string id , string claim);
        Task<bool> revokeRoleClaim(string id, string claim);

    }
}
