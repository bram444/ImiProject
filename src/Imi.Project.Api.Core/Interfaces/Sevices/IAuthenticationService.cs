using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IAuthenticationService
    {
        Task<AuthenticateResult> Login(LoginRequestModel loginUser);
        Task<AuthenticateResult> RegisterAsync(RegisterModel registration);
        Task Logout();
    }
}
