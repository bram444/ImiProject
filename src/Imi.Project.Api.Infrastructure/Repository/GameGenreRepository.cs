using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            } catch(Exception ex)
            {
                throw new Exception("Something went wrong when getting all GameGenre", ex.InnerException);
            }
        }

        public virtual async Task<IEnumerable<GameGenre>> GetByGameIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<GameGenre>().Where(gg => gg.GameId == id).AsNoTracking().ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all GameGenre with Game Id {id}", ex.InnerException);
            }
        }

        public virtual async Task<IEnumerable<GameGenre>> GetByGenreIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<GameGenre>().Where(gg => gg.GenreId == id).AsNoTracking().ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all GameGenre with genre Id {id}", ex.InnerException);
            }
        }

        public virtual async Task<bool> DoesExistAsync(Expression<Func<GameGenre, bool>> predicate)
        {
            try
            {
                return await _dbContext.Set<GameGenre>().Where(predicate).AnyAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when checking if {typeof(GameGenre).Name} already exists", ex.InnerException);
            }
        }

        public async Task AddAsync(GameGenre entity)
        {
            try
            {
                await _dbContext.Set<GameGenre>().AddAsync(entity);
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