using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<User>> SearchFirstNameAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> SearchLastNameAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> SearchUserNameAsync(string search)
        {
            throw new NotImplementedException();
        }
    }
}
