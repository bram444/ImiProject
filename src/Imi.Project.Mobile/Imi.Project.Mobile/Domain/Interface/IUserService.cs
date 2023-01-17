using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Interface
{
    public interface IUserService: IBaseService<UserInfo, RegistrationInfo, UpdateUserInfo>
    {
    }
}