using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IGameGenreRepository
    {
        IQueryable<GameGenre> GetAll();
        Task<IEnumerable<GameGenre>> ListAllAsync();
        Task<IEnumerable<GameGenre>> GetByGameIdAsync(Guid id);
        Task<IEnumerable<GameGenre>> GetByGenreIdAsync(Guid id);
        Task<GameGenre> AddAsync(GameGenre entity);
        Task<GameGenre> DeleteAsync(GameGenre entity);
    }
}