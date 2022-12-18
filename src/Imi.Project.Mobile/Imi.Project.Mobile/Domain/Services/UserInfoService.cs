using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Services
{
    public class UserInfoService: BaseService<UserInfo>, IUserService
    {
        public UserInfoService(CustomHttpClient customHttpClient) : base(customHttpClient, "/api/User")
        {
        }
    }
}