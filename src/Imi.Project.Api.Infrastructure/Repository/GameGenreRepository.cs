using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class GameGenreRepository : IGameGenreRepository
    {

        protected readonly ApplicationDbContext _dbContext;
        public GameGenreRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<GameGenre> GetAll()
        {
            return _dbContext.Set<GameGenre>().AsQueryable();
        }
        public virtual async Task<IEnumerable<GameGenre>> ListAllAsync()
        {
            return await _dbContext.Set<GameGenre>().AsNoTracking().ToListAsync();
        }
        public virtual async Task<IEnumerable<GameGenre>> GetByGameIdAsync(Guid id)
        {
            var gameGenre = await ListAllAsync();
            return gameGenre.Where(gg => gg.GameId == id);
        }

        public virtual async Task<IEnumerable< GameGenre>> GetByGenreIdAsync(Guid id)
        {
            var gameGenre = await ListAllAsync();
            return gameGenre.Where(gg => gg.GameId == id);
        }

        public async Task<GameGenre> AddAsync(GameGenre entity)
        {
            _dbContext.Set<GameGenre>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<GameGenre> DeleteAsync(GameGenre entity)
        {
            _dbContext.Set<GameGenre>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
