using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.Permission;
using Talabat.Application.Repository.Interfaces;
using Talabat.Infrastructure.Models;

namespace Talabat.Infrastructure.Presistance.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public PermissionRepository(RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }


        public Task<string> createRoleClaim(string id, string claimValue)
        {
            throw new NotImplementedException();
        }

        public Task<string> createUserClaim(string id, string claimValue)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IList<PermissionResponseDTO>> getRolesClaims(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role == null) throw new NotImplementedException();
            IList<Claim> claims = await _roleManager.GetClaimsAsync(role);
            return claims.Select(a => new PermissionResponseDTO()
            {
                Id = a.Issuer,
                ClaimValue = a.Value,
                Type = a.Type
            }).ToList();
        }

        public async Task<IList<Claim>> getUserClaims(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            IList<Claim> claims = await _userManager.GetClaimsAsync(user);
            return claims;
        }
        public Task<bool> revokeRoleClaim(string id, string claim)
        {
            throw new NotImplementedException();
        }

        public Task<bool> revokeUserClaim(string id, string claim)
        {
            throw new NotImplementedException();
        }
    }
}
