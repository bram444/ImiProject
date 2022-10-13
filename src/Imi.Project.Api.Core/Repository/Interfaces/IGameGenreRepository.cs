using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Repository.Interfaces
{
    public interface IGameGenreRepository
    {
        IQueryable<GameGenre> GetAll();
        Task<IEnumerable<GameGenre>> ListAllAsync();
        Task<GameGenre> GetByGameIdAsync(Guid id);
        Task<GameGenre> GetByGenreIdAsync(Guid id);

        Task<GameGenre> UpdateAsync(GameGenre entity);
        Task<GameGenre> AddAsync(GameGenre entity);
        Task<GameGenre> DeleteAsync(GameGenre entity);
    }
}
