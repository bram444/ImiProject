using Imi.Project.Mobile.Domain.Model;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Interface
{
    public interface IAuthenticationService
    {
        Task<TokenResponse> Login(LogInInfo login);

        Task<TokenResponse> Registration(RegistrationInfo registration);
    }
}
