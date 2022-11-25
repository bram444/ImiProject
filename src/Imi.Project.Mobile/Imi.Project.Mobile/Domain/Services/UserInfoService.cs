using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Domain.Services
{
    public class UserInfoService
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

        public void SaveUser(UserInfo userInfo)
        {
            var userInfoEdit = UserById(userInfo.Id);
            userInfoEdit.Result.Email = userInfo.Email;
            userInfoEdit.Result.FirstName = userInfo.FirstName;
            userInfoEdit.Result.LastName = userInfo.LastName;
            userInfoEdit.Result.UserName = userInfo.UserName;
        }

        public void AddUser(UserInfo userInfo)
        {
            inMemoryUser.Add(userInfo);
        }

        public void RemoveUser(Guid id)
        {
            inMemoryUser.Remove(UserById(id).Result);
        }
    }
}