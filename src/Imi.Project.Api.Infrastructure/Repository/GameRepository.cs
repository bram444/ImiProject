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
            try
            {
                return await GetAll().Where(p => p.PublisherId.Equals(id)).AsNoTracking().ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong with getting game with PublisherId {id}", ex.InnerException);
            }

        }

        public virtual async Task<IEnumerable<Game>> SearchAsync(string search)
        {
            try
            {
                return await GetAll()
                    .Where(g => g.Name.Contains(search.Trim().ToUpper())).AsNoTracking()
                    .ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong with getting game with name {search}", ex.InnerException);
            }
        }
    }
}