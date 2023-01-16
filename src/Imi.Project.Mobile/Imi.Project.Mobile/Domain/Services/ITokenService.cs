using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Imi.Project.Mobile.Domain.Services
{
    public interface ITokenService
    {
        IEnumerable<Claim> GetClaims(string Token);
        bool IsAdmin(string Token);
        Guid GetId(string Token);

    }
}
