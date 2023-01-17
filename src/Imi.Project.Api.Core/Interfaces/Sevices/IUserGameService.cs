using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.UserGame;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IUserGameService: IBaseGameMTMService<UserGame, UserGameModel>
    {
        Task<ServiceResultModel<IEnumerable<UserGame>>> GetByUserIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<UserGame>>> EditUserGameAsync(UpdateUserGameModel model);
    }
}