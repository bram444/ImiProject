using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGameGenreService
    {
        IQueryable<GameGenre> GetAll();
        Task<IEnumerable<GameGenre>> ListAllAsync();
        Task<GameGenre> GetByGameIdAsync(Guid id);
        Task<GameGenre> GetByGenreIdAsync(Guid id);

        Task<GameGenre> UpdateAsync(GameGenreResponseDto entity);
        Task<GameGenre> AddAsync(GameGenreResponseDto entity);
        Task<GameGenre> DeleteAsync(GameGenreResponseDto entity);
    }
}
