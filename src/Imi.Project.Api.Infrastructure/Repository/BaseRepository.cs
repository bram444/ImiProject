using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class BaseRepository<T>: IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return _dbContext.Set<T>().AsQueryable();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while getting all {nameof(T)}", ex.InnerException);
            }
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            try
            {
                return await _dbContext.Set<T>().ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while getting all {nameof(T)}", ex.InnerException);
            }
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<T>().SingleOrDefaultAsync(t => t.Id == id);
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while getting {nameof(T)} with Id {id}", ex.InnerException);
            }
        }

        public async Task<bool> DoesExistAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<T>().AnyAsync(t => t.Id == id);
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when checking if {nameof(T)} with id {id} already exists", ex.InnerException);
            }
        }

        public async Task<bool> DoesExistAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbContext.Set<T>().AnyAsync(predicate);
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when checking if {nameof(T)} already exists", ex.InnerException);
            }
        }

        public async Task<IEnumerable<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await GetAll().Where(predicate).ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting a filtered list of {typeof(T).Name}", ex.InnerException);
            }
        }

        //public bool DoesListExist(ICollection<Guid> ids)
        //{
        //    try
        //    {
        //        return ids.All(id => GetAll().Any(t => t.Id == id));

        //    } catch(Exception ex)
        //    {
        //        throw new Exception($"Something went wrong when checking if all {typeof(T).Name} in a list exists", ex.InnerException);
        //    }
        //}

        //public async Task<IEnumerable<Guid>> GetNonExistend(IEnumerable<Guid> ids)
        //{
        //    return ids.Except((await ListAllAsync()).Select(t => t.Id));
        //}

        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while adding {nameof(T)}", ex.InnerException);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while updating {nameof(T)}", ex.InnerException);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while removing {nameof(T)}", ex.InnerException);
            }
        }
    }
}