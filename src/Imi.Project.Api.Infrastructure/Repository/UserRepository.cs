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
    public class UserRepository: IUserRepository
    {

        protected readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            try
            {
                return _dbContext.ApplicationUsers.AsQueryable();
            } catch(Exception ex)
            {
                throw new Exception("Something went wrong when getting all users", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ApplicationUser>> ListAllAsync()
        {
            try
            {
                return await _dbContext.ApplicationUsers.ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception("Something went wrong when getting all users", ex.InnerException);
            }
        }

        public async Task<ApplicationUser> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.ApplicationUsers.SingleOrDefaultAsync(t => t.Id == id);
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting the user with id {id}", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ApplicationUser>> SearchUserNameAsync(string search)
        {
            try
            {
                return await GetAll()
                .Where(g => g.UserName.Contains(search))
                .ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all users with username {search}", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ApplicationUser>> SearchFirstNameAsync(string search)
        {
            try
            {
                return await GetAll()
                .Where(user => user.FirstName.Contains(search))
                .ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all users with firstname {search}", ex.InnerException);
            }
        }

        //public virtual async Task<IEnumerable<ApplicationUser>> SearchEmailAsync(string search)
        //{
        //    return await GetAll()
        //        .Where(g => g.Email.Contains(search.Trim().ToUpper()))
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<ApplicationUser>> SearchLastNameAsync(string search)
        {
            try
            {
                return await GetAll()
                    .Where(g => g.LastName.Contains(search))
                    .ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all users with lastname {search}", ex.InnerException);
            }
        }

        public async Task<bool> DoesExistAsync(Guid id)
        {
            try
            {
                return await _dbContext.ApplicationUsers.AnyAsync(t => t.Id == id);
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when checking if {nameof(ApplicationUser)} with id {id} already exists", ex.InnerException);
            }
        }

        public async Task<bool> DoesExistAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            try
            {
                return await _dbContext.ApplicationUsers.Where(predicate).AnyAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when checking if {nameof(ApplicationUser)} already exists", ex.InnerException);
            }
        }

        //public async Task<IEnumerable<ApplicationUser>> GetFilteredListAsync(Expression<Func<ApplicationUser, bool>> predicate)
        //{
        //    return await GetAll().Where(predicate).ToListAsync();
        //}

        public async Task AddAsync(ApplicationUser entity)
        {
            try
            {
                await _dbContext.ApplicationUsers.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while adding {nameof(ApplicationUser)}", ex.InnerException);
            }
        }

        public async Task UpdateAsync(ApplicationUser entity)
        {
            try
            {
                _dbContext.ApplicationUsers.Update(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while updating {nameof(ApplicationUser)}", ex.InnerException);
            }
        }

        public async Task DeleteAsync(ApplicationUser entity)
        {
            try
            {
                _dbContext.ApplicationUsers.Remove(entity);
                await _dbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong while removing {nameof(ApplicationUser)}", ex.InnerException);
            }
        }
    }
}