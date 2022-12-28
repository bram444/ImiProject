using Imi.Project.Api.Core.Interfaces.Sevices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            List<Claim> claims = new();
            claims.AddRange(userClaims);
            int expirationDays = int.Parse(_configuration["JWTConfiguration:TokenExpirationDays"]);
            string signinKey = _configuration["JWTConfiguration:SigninKey"];
            JwtSecurityToken token = new(
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
