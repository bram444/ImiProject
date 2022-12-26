using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IUserGameService
    {
        Task<ServiceResultModel< IEnumerable<UserGame>>> ListAllAsync();
        Task<ServiceResultModel<IEnumerable<UserGame>>> GetByGameIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<UserGame>>> GetByUserIdAsync(Guid id);
        Task<ServiceResultModel<UserGame>> AddAsync(UserGameModel model);
        Task<ServiceResultModel<IEnumerable<UserGame>>> EditUserGameAsync(UserRequestModel model);
        Task<ServiceResultModel<UserGame>> DeleteAsync(UserGameModel model);
    }
}