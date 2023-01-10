using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IJwtService
    {
        JwtSecurityToken GenerateToken(List<Claim> userClaims);
        string SerializeToken(JwtSecurityToken token);

        JwtSecurityToken DecodeToken(string token);

    }
}