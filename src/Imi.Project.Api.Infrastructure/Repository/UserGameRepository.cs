using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class UserGameRepository: IUserGameRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public UserGameRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<UserGame> GetAll()
        {
            return _dbContext.Set<UserGame>().AsQueryable();
        }

        public virtual async Task<IEnumerable<UserGame>> ListAllAsync()
        {
            try
            {
                return await _dbContext.Set<UserGame>().AsNoTracking().ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception("Something went wrong when getting all UserGame", ex.InnerException);
            }
        }

        public virtual async Task<IEnumerable<UserGame>> GetByGameIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<UserGame>().AsNoTracking().Where(ug => ug.GameId == id).ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all UserGame with Game Id {id}", ex.InnerException);
            }
        }

        public virtual async Task<IEnumerable<UserGame>> GetByUserIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<UserGame>().AsNoTracking().Where(ug => ug.UserId == id).ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all UserGame with User Id {id}", ex.InnerException);
            }
        }

        public async Task AddAsync(UserGame entity)
        {
            try
            {
                _dbContext.Set<UserGame>().Add(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while adding {typeof(UserGame).Name}", ex.InnerException);
            }
        }

        public async Task DeleteAsync(UserGame entity)
        {
            try
            {
                _dbContext.Set<UserGame>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while removing {typeof(UserGame).Name}", ex.InnerException);
            }
        }
    }
}