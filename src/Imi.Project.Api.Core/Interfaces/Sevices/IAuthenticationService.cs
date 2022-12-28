using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Authentiction;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IAuthenticationService
    {
        Task<AuthenticateResult> Login(LoginRequestModel loginUser);
        Task<AuthenticateResult> RegisterAsync(RegistrationModel registration);
        Task Logout();
    }
}
