using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class UserGameRepository: BaseGameMTMRepository<UserGame>, IUserGameRepository
    {
        public UserGameRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        //public virtual IQueryable<UserGame> GetAll()
        //{
        //    return _dbContext.UsersGames.AsQueryable();
        //}

        //public virtual async Task<IEnumerable<UserGame>> ListAllAsync()
        //{
        //    try
        //    {
        //        return await _dbContext.UsersGames.AsNoTracking().ToListAsync();
        //    } catch(Exception ex)
        //    {
        //        throw new Exception("Something went wrong when getting all UserGame", ex.InnerException);
        //    }
        //}

        public async Task<IEnumerable<UserGame>> GetByUserIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.UsersGames.Where(ug => ug.UserId == id).AsNoTracking().ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all UserGame with User Id {id}", ex.InnerException);
            }
        }
    }
}