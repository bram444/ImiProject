using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class UserGameRepository : IUserGameRepository
    {
        public Task<UserGame> AddAsync(UserGame entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserGame> DeleteAsync(UserGame entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserGame> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserGame> GetByGameIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserGame> GetByUserIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserGame>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserGame> UpdateAsync(UserGame entity)
        {
            throw new NotImplementedException();
        }
    }
}
