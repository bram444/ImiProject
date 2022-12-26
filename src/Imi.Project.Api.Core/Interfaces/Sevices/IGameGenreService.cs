using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGameGenreService
    {
        Task<ServiceResultModel<IEnumerable<GameGenre>>> ListAllAsync();
        Task<ServiceResultModel<IEnumerable<GameGenre>>> GetByGameIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<GameGenre>>> GetByGenreIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<GameGenre>>> EditGameGenreAsync(GameModel gameResponseDto);
        Task<ServiceResultModel<GameGenre>> AddAsync(GameGenreModel gameGenreModel);
        Task<ServiceResultModel<GameGenre>> DeleteAsync(GameGenreModel gameGenreModel);
    }
}