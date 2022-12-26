using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
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
            return _dbContext.Set<T>().AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            try
            {

                return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
            }catch(Exception ex)
            {
                throw new Exception($"Something went wrong while getting all {typeof(T).Name}",ex.InnerException);
            }

        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while getting {typeof(T).Name} with Id {id}", ex.InnerException);
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                entity.CreatedOn = DateTime.UtcNow;
                entity.LastEditedOn = DateTime.UtcNow;
                _dbContext.Set<T>().Add(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while adding {typeof(T).Name}", ex.InnerException);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                entity.LastEditedOn = DateTime.UtcNow;
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while updating {typeof(T).Name}", ex.InnerException);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.Entry(entity).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while removing {typeof(T).Name}", ex.InnerException);
            }
        }
    }
}