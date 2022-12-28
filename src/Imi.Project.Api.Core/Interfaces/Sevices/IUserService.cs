using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IUserService
    {
        Task<ServiceResultModel<IEnumerable<ApplicationUser>>> ListAllAsync();
        Task<ServiceResultModel<ApplicationUser>> GetByIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<ApplicationUser>>> SearchUserNameAsync(string search);
        Task<ServiceResultModel<IEnumerable<ApplicationUser>>> SearchFirstNameAsync(string search);
        Task<ServiceResultModel<IEnumerable<ApplicationUser>>> SearchLastNameAsync(string search);
        Task<ServiceResultModel<ApplicationUser>> AddAsync(NewUserModel response);
        Task<ServiceResultModel<ApplicationUser>> UpdateAsync(UpdateUserModel response);
        Task<ServiceResultModel<ApplicationUser>> DeleteAsync(Guid id);
    }
}