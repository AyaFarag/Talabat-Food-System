using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.DTO.Auth;
using Talabat.Application.DTO.User;
using Talabat.Application.Extentions;
using Talabat.Application.Repository.Interfaces;

namespace Talabat.Application.Contracts.Services
{
    public class TokenServiceImple : ITokenService
    {
        private readonly IConfiguration _configuration;
        // private readonly IRoleService _roleService;
        private readonly IPermissionRepository _permissionRepository;
        private readonly SymmetricSecurityKey _secretKey;
        private readonly string? _validIssuer;
        private readonly string? _validAudience;
        private readonly double _expires;

        public TokenServiceImple(IConfiguration configuration, 
            IRoleService roleService,
            IPermissionRepository permissionRepository)
        {
           _permissionRepository = permissionRepository;
            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>(); // mapping
            if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.SecretKey))
            {
                throw new InvalidOperationException("JWT secret key is not configured.");
            }

            _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            _validIssuer = jwtSettings.Issuer;
            _validAudience = jwtSettings.Audience;
            _expires = jwtSettings.Expires;
        }

        public async Task<string> GenerateToken(UserResponse user)
        {
            // steps to generate token

            var singingCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);
            var claims = await _permissionRepository.getUserClaims(user.Id.ToString());
            var tokenOptions = GenerateTokenOptions(singingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions); // token string
        }



        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IList<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: _validIssuer,
                audience: _validAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_expires),
                signingCredentials: signingCredentials
            );
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            var refreshToken = Convert.ToBase64String(randomNumber);
            return refreshToken;
        }




        //private async Task<List<Claim>> GetClaimsAsync(UserResponse user)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user?.UserName ?? string.Empty),
        //        new Claim(ClaimTypes.NameIdentifier, user?.Id ?? string.Empty),
        //        new Claim(ClaimTypes.Email, user?.Email ?? string.Empty),
        //        new Claim("FirstName", user?.FirstName ?? string.Empty),
        //        new Claim("LastName", user?.LastName ?? string.Empty),
        //        new Claim("Gender", user?.Gender ?? string.Empty)
        //    };

        //    var roles = await _roleService.getRoles(user);
        //    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        //    return claims;
        //}

    }
}
