using Imi.Project.Api.Core.Interfaces.Sevices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class JwtService: IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtSecurityToken GenerateToken(List<Claim> userClaims)
        {
            var claims = new List<Claim>();
            claims.AddRange(userClaims);
            var expirationDays = int.Parse(_configuration["JWTConfiguration:TokenExpirationDays"]);
            var signinKey = _configuration["JWTConfiguration:SigninKey"];
            var token = new JwtSecurityToken
            (
                issuer: _configuration["JWTConfiguration:Issuer"],
                audience: _configuration["JWTConfiguration:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey))
                , SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

        public string SerializeToken(JwtSecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
