using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class GameGenreRepository : IGameGenreRepository
    {
        public Task<GameGenre> AddAsync(GameGenre entity)
        {
            throw new NotImplementedException();
        }

        public Task<GameGenre> DeleteAsync(GameGenre entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GameGenre> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GameGenre> GetByGameIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GameGenre> GetByGenreIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameGenre>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GameGenre> UpdateAsync(GameGenre entity)
        {
            throw new NotImplementedException();
        }
    }
}
