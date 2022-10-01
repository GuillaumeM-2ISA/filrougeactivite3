using DAL.UOW;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
    class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _dbContext;

        public SecurityService(IConfiguration configuration, IUnitOfWork dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<string> SigninAsync(string username, string password)
        {
            //if (username == "admin" && password == "admin")
            //{
            //    return GenerateJwtToken("admin", new List<string>() { "ADMIN", "USER" });
            //}
            //else if (username == "user" && password == "user")
            //{
            //    return GenerateJwtToken("user", new List<string>() { "USER" });
            //}

            Member member = await _dbContext.Members.GetByNicknameAndPasswordAsync(username, password);
            if (member.Type == "Moderator") return GenerateJwtToken(username, new List<string>() { "MEMBER", "MODERATOR" });
            return GenerateJwtToken(username, new List<string>() { "MEMBER" });

            // Si l'utilisateur existe ou non
            // Généré le token avec les bon roles
            // Renvoie le token ou AuthentificationFailException
        }

        private string GenerateJwtToken(string username, List<string> roles)
        {
            //Add User Infos
            var claims = new List<Claim>(){
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username)
            };

            //Add Roles
            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            //Signin Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Expiration time
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            //Create JWT Token Object
            var token = new JwtSecurityToken(
            _configuration["JwtIssuer"],
            _configuration["JwtAudiences"],
            claims,
            expires: expires,
            signingCredentials: creds
            );

            //Serializes a JwtSecurityToken into a JWT in Compact Serialization Format.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
