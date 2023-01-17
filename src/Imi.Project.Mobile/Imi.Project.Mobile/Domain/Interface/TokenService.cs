using Imi.Project.Mobile.Domain.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Imi.Project.Mobile.Domain.Interface
{
    public class TokenService: ITokenService
    {
        public IEnumerable<Claim> GetClaims(string Token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(Token);
            return jwtSecurityToken.Claims;
        }

        public bool IsAdmin(string Token)
        {
            if(Token == null)
            {
                return false;
            }

            IEnumerable<Claim> claims = GetClaims(Token);
            return claims.First(claim => claim.Type == ClaimTypes.Role).Value == "Admin";
        }

        public Guid GetId(string Token)
        {
            if(Token == null)
            {
                return Guid.Empty;
            }

            IEnumerable<Claim> claims = GetClaims(Token);
            return Guid.Parse(claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}
