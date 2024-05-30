using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

using TI_Devops_2024_DemoAspMvc.BLL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string Generate(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                _config["jwt:issuer"],
                _config["jwt:audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials : creds
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
