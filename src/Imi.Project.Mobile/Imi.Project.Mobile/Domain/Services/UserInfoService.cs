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
        private static List<UserInfo> inMemoryUser = new List<UserInfo>
        {
            new UserInfo
            {
                Id= Guid.Parse("00000000-0000-0000-0000-000000000001"),
                 Email="Email@email.com",
                  FirstName="First",
                  LastName="Guy",
                   UserName="Firstguy111"
            }
        };
        public async Task<List<UserInfo>> GetAllUser()
        {
            return await Task.FromResult(inMemoryUser);
        }

        public async Task<UserInfo> UserById(Guid id)
        {
            return await Task.FromResult(inMemoryUser.Where(user => user.Id == id).First());
        }

        public Task<UserInfo> UpdateUser(UserInfo user)
        {
            var userInfoEdit = UserById(user.Id);
            userInfoEdit.Result.Email = user.Email;
            userInfoEdit.Result.FirstName = user.FirstName;
            userInfoEdit.Result.LastName = user.LastName;
            userInfoEdit.Result.UserName = user.UserName;

            return userInfoEdit;
        }

        public Task DeleteUser(Guid id)
        {
            inMemoryUser.Remove(UserById(id).Result);
            return Task.CompletedTask;
        }

        public Task<UserInfo> AddUser(UserInfo user)
        {
            inMemoryUser.Add(user);
            return UserById(user.Id);
        }
    }
}