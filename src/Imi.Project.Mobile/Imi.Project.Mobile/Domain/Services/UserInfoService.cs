using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Domain.Services
{
    public class UserInfoService:IUserService
    {
        string baseUrl = Constants.baseUrl;

        private readonly CustomHttpClient _httpClient = new CustomHttpClient();

        public UserInfoService(CustomHttpClient customHttpClient)
        {
            _httpClient = customHttpClient;
        }

        public async Task<IEnumerable<UserInfo>> GetAllUser()
        {
            return await _httpClient.GetApiResult<IEnumerable<UserInfo>>($"{baseUrl}/api/User/");
        }

        public async Task<UserInfo> UserById(Guid id)
        {
            return await _httpClient.GetApiResult<UserInfo>($"{baseUrl}/api/User/{id}");
        }

        public async Task<UserInfo> UpdateUser(UserInfo user)
        {
            return await _httpClient.PutCallApi<UserInfo, UserInfo>($"{baseUrl}/api/User/", user);

        }

        public async Task<UserInfo> DeleteUser(Guid id)
        {
            return await _httpClient.DeleteCallApi<UserInfo>($"{baseUrl}/api/User/{id}");

        }

        public async Task<UserInfo> AddUser(UserInfo user)
        {
            return await _httpClient.PostCallApi<UserInfo, UserInfo>($"{baseUrl}/api/User", user);

        }
    }
}