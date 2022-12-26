using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IGameGenreRepository
    {
        IQueryable<GameGenre> GetAll();
        Task<IEnumerable<GameGenre>> ListAllAsync();
        Task<IEnumerable<GameGenre>> GetByGameIdAsync(Guid id);
        Task<IEnumerable<GameGenre>> GetByGenreIdAsync(Guid id);
        Task AddAsync(GameGenre entity);
        Task DeleteAsync(GameGenre entity);
    }
}