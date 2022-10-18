using Imi.Project.Api.Core.Dto.UserGame;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class UserGameRepository : IUserGameRepository
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
            return await _dbContext.Set<UserGame>().ToListAsync();
        }

        public virtual async Task<UserGame> GetByGameIdAsync(Guid id)
        {
            return await _dbContext.Set<UserGame>().SingleOrDefaultAsync(t => t.GameId.Equals(id));
        }

        public virtual async Task<UserGame> GetByUserIdAsync(Guid id)
        {
            return await _dbContext.Set<UserGame>().SingleOrDefaultAsync(t => t.UserId.Equals(id));
        }

        public async Task<UserGame> AddAsync(UserGame entity)
        {
            _dbContext.Set<UserGame>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<UserGame> DeleteAsync(UserGame entity)
        {
            _dbContext.Set<UserGame>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<UserGame> UpdateAsync(UserGame entity)
        {
            _dbContext.Set<UserGame>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
