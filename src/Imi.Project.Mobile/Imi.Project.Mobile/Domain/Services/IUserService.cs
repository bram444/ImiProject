﻿using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public interface IUserService
    {
        Task<List<UserInfo>> GetAllUser();

        Task<UserInfo> UserById(Guid id);

        Task<UserInfo> UpdateUser(UserInfo user);

        Task DeleteUser(Guid id);

        Task<UserInfo> AddUser(UserInfo user);
    }
}