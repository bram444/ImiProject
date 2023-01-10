using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Authentication;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> Login(LoginRequestModel loginUser);
        Task<AuthenticationResult> RegisterAsync(RegistrationModel registration);
        Task<string> RefreshToken(string token);
        Task Logout();
    }
}