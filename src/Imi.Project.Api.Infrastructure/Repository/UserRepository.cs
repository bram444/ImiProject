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
    public class UserRepository: IUserRepository
    {

        protected readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<ApplicationUser> GetAll()
        {
            return _dbContext.Set<ApplicationUser>().AsQueryable();
        }

        public virtual async Task<IEnumerable<ApplicationUser>> ListAllAsync()
        {
            return await _dbContext.Set<ApplicationUser>().ToListAsync();
        }

        public virtual async Task<ApplicationUser> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<ApplicationUser>().SingleOrDefaultAsync(t => t.Id == id);
        }

        public virtual async Task<IEnumerable<ApplicationUser>> SearchUserNameAsync(string search)
        {
            return await GetAll()
                .Where(g => g.UserName.Contains(search.Trim().ToUpper()))
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<ApplicationUser>> SearchFirstNameAsync(string search)
        {
            return await GetAll()
                .Where(g => g.FirstName.Contains(search.Trim().ToUpper()))
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<ApplicationUser>> SearchEmailAsync(string search)
        {
            return await GetAll()
                .Where(g => g.Email.Contains(search.Trim().ToUpper()))
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<ApplicationUser>> SearchLastNameAsync(string search)
        {
            return await GetAll()
                .Where(g => g.LastName.Contains(search.Trim().ToUpper()))
                .ToListAsync();
        }

        public virtual async Task<bool> DoesExistAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<ApplicationUser>().AnyAsync(t => t.Id == id);
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when checking if {typeof(ApplicationUser).Name} with id {id} already exists", ex.InnerException);
            }
        }

        public virtual async Task<bool> DoesExistAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            try
            {
                return await _dbContext.Set<ApplicationUser>().Where(predicate).AnyAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when checking if {typeof(ApplicationUser).Name} already exists", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetFilteredListAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }
        public async Task AddAsync(ApplicationUser entity)
        {
            try
            {
                await _dbContext.Set<ApplicationUser>().AddAsync(entity);
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
                await _dbContext.SaveChangesAsync();

            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while removing {typeof(ApplicationUser).Name}", ex.InnerException);
            }
        }
    }
}