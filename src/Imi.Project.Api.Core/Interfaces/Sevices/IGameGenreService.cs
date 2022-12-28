using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.GameGenre;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGameGenreService:IBaseGameMTMService<GameGenre>
    {
        Task<ServiceResultModel<IEnumerable<GameGenre>>> GetByGenreIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<GameGenre>>> EditGameGenreAsync(UpdateGameGenreModel updateGameGenre);
        Task<ServiceResultModel<GameGenre>> AddAsync(GameGenreModel gameGenreModel);
        Task<ServiceResultModel<GameGenre>> DeleteAsync(GameGenreModel gameGenreModel);
    }
}