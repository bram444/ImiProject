using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserInfo>> GetAllUser();
        Task<UserInfo> UserById(Guid id);
        Task<UserInfo> UpdateUser(UserInfo user);
        Task<UserInfo> DeleteUser(Guid id);
        Task<UserInfo> AddUser(UserInfo user);
    }
}