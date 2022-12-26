using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class UserRepository: IUserRepository
    {

        protected readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IEnumerable<ApplicationUser>> SearchFirstNameAsync(string search)
        {
            return await GetAll()
                .Where(g => g.FirstName.Contains(search.Trim().ToUpper())).AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<ApplicationUser>> SearchLastNameAsync(string search)
        {
            return await GetAll()
                .Where(g => g.LastName.Contains(search.Trim().ToUpper())).AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<ApplicationUser>> SearchEmailAsync(string search)
        {
            return await GetAll()
                .Where(g => g.Email.Contains(search.Trim().ToUpper())).AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<ApplicationUser>> SearchUserNameAsync(string search)
        {
            return await GetAll()
                .Where(g => g.UserName.Contains(search.Trim().ToUpper())).AsNoTracking()
                .ToListAsync();
        }

        public virtual IQueryable<ApplicationUser> GetAll()
        {
            return _dbContext.Set<ApplicationUser>().AsQueryable();
        }

        public virtual async Task<IEnumerable<ApplicationUser>> ListAllAsync()
        {
            return await _dbContext.Set<ApplicationUser>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<ApplicationUser> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<ApplicationUser>().AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(ApplicationUser entity)
        {
            try
            {
                _dbContext.Set<ApplicationUser>().Add(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while adding {typeof(ApplicationUser).Name}", ex.InnerException);
            }
        }

        public async Task UpdateAsync(ApplicationUser entity)
        {
            try
            {
                _dbContext.Set<ApplicationUser>().Update(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while updating {typeof(ApplicationUser).Name}", ex.InnerException);
            }
        }

        public async Task DeleteAsync(ApplicationUser entity)
        {
            try
            {
                _dbContext.Set<ApplicationUser>().Remove(entity);
                _dbContext.Entry(entity).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();

            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while removing {typeof(ApplicationUser).Name}", ex.InnerException);
            }
        }
    }
}