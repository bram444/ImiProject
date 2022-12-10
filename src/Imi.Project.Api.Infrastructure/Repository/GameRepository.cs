using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class GameRepository: BaseRepository<Game>, IGameRepository
    {

        public GameRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Game>> GetByPublisherIdAsync(Guid id)
        {
            List<Game> game = await GetAll().Where(p => p.PublisherId.Equals(id)).AsNoTracking().ToListAsync();
            return game;
        }

        public virtual async Task<IEnumerable<Game>> SearchAsync(string search)
        {
            List<Game> games = await GetAll()
                .Where(g => g.Name.Contains(search.Trim().ToUpper()))
                .ToListAsync();

            return games;
        }
    }
}