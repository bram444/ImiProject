using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class UserInfoService: BaseService<UserInfo>, IUserService
    {
        public UserInfoService(CustomHttpClient customHttpClient):base(customHttpClient, "/api/User")
        {
        }
    }
}