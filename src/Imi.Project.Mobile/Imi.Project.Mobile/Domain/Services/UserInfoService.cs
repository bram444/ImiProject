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
        private readonly CustomHttpClient _httpClient = new CustomHttpClient();

        public UserInfoService(CustomHttpClient customHttpClient)
        {
            _httpClient = customHttpClient;
        }

        public async Task<List<UserInfo>> GetAllUser()
        {
            return await _httpClient.GetApiResult<List<UserInfo>>("https://172.31.224.1:5001/api/User/");
        }

        public async Task<UserInfo> UserById(Guid id)
        {
            return await _httpClient.GetApiResult<UserInfo>($"https://172.31.224.1:5001/api/User/{id}");
        }

        public async Task<UserInfo> UpdateUser(UserInfo user)
        {
            return await _httpClient.PutCallApi<UserInfo, UserInfo>($"https://172.31.224.1:5001/api/User/{user.Id}", user);

        }

        public async Task<UserInfo> DeleteUser(Guid id)
        {
            return await _httpClient.DeleteCallApi<UserInfo>($"https://172.31.224.1:5001/api/User/{id}");

        }

        public async Task<UserInfo> AddUser(UserInfo user)
        {
            return await _httpClient.PostCallApi<UserInfo, UserInfo>($"https://172.31.224.1:5001/api/User", user);

        }
    }
}