using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class BaseGameMTMRepository<MTM>: IBaseGameMTMRepository<MTM>
        where MTM : BaseGameMTM
    {

        protected readonly ApplicationDbContext _dbContext;

        public BaseGameMTMRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MTM>> GetByGameIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<MTM>().Where(gg => gg.GameId == id).AsNoTracking().ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all {nameof(MTM)} with Game Id {id}", ex.InnerException);
            }
        }

        public async Task<bool> DoesExistAsync(Expression<Func<MTM, bool>> predicate)
        {
            try
            {
                return await _dbContext.Set<MTM>().AnyAsync(predicate);
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when checking if {nameof(MTM)} already exists", ex.InnerException);
            }
        }

        public async Task AddAsync(MTM entity)
        {
            try
            {
                await _dbContext.Set<MTM>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while adding {nameof(MTM)}", ex.InnerException);
            }
        }

        public async Task DeleteAsync(MTM entity)
        {
            try
            {
                _dbContext.Set<MTM>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while removing {nameof(MTM)}", ex.InnerException);
            }
        }
    }
}