using Algoriza_Project_2023BE83.Helpers;
using Algoriza_Project_2023BE83.Models;
using Core.Domain;
using Core.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Users> _userManager;
        private readonly JWT _jwt;
        public AuthService (UserManager<Users> userManager,IOptions<JWT>jwt) 
        { 
            _userManager = userManager;
            _jwt = jwt.Value;
        }
        public async Task<Auth> RegisterAsync(Register model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null) 
            {
                return new Auth { Message = "Email is already registered!" };
            }
            if (await _userManager.FindByNameAsync(model.Username) is not null)
            {
                return new Auth { Message = "Username is already registered!" };
            }
            var user = new Users
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,                
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if(!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new Auth { Message = errors };
            }
            await _userManager.AddToRoleAsync(user, "User");
        }
        private async Task<JwtSecurityToken> CreateJwtToken(Users user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }

}
}
