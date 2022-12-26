using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class GameGenreRepository: IGameGenreRepository
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
            try
            {
                return await _dbContext.Set<GameGenre>().AsNoTracking().ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Something went wrong when getting all GameGenre", ex.InnerException);
            }
        }
        public virtual async Task<IEnumerable<GameGenre>> GetByGameIdAsync(Guid id)
        {
            try
            {
                IEnumerable<GameGenre> gameGenre = await ListAllAsync();
                return gameGenre.Where(gg => gg.GameId == id);
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all GameGenre with Game Id {id}", ex.InnerException);
            }
        }

        public virtual async Task<IEnumerable<GameGenre>> GetByGenreIdAsync(Guid id)
        {
            try
            { 
            IEnumerable<GameGenre> gameGenre = await ListAllAsync();
            return gameGenre.Where(gg => gg.GenreId == id);
        } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all GameGenre with genre Id {id}", ex.InnerException);
    }
}

        public async Task AddAsync(GameGenre entity)
        {
            try
            {
                _dbContext.Set<GameGenre>().Add(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while adding {typeof(GameGenre).Name}", ex.InnerException);
            }
        }

        public async Task DeleteAsync(GameGenre entity)
        {
            try
            {
                _dbContext.Set<GameGenre>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while removing {typeof(GameGenre).Name}", ex.InnerException);
            }
        }
    }
}