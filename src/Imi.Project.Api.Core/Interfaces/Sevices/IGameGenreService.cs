using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGameGenreService
    {
        IQueryable<GameGenreResponseDto> GetAll();
        Task<IEnumerable<GameGenreResponseDto>> ListAllAsync();
        Task<IEnumerable<GameGenreResponseDto>> GetByGameIdAsync(Guid id);
        Task<IEnumerable<GameGenreResponseDto>> GetByGenreIdAsync(Guid id);

        Task<ServiceResult<GameGenreResponseDto>> AddAsync(GameGenreResponseDto entity);
        Task<ServiceResult<GameGenreResponseDto>> DeleteAsync(GameGenreResponseDto entity);
    }
}
