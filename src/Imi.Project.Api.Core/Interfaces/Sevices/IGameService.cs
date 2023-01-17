using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.Game;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGameService: IBaseService<Game, NewGameModel, UpdateGameModel>
    {
        Task<ServiceResultModel<IEnumerable<Game>>> GetByPublisherIdAsync(Guid id);
    }
}