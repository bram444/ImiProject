using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public virtual async Task<IEnumerable<User>> SearchFirstNameAsync(string search)
        {
            var user = await GetAll()
                .Where(g => g.FirstName.Contains(search.Trim().ToUpper()))
                .ToListAsync();

            return user;
        }

        public virtual async Task<IEnumerable<User>> SearchLastNameAsync(string search)
        {
            var user = await GetAll()
                .Where(g => g.LastName.Contains(search.Trim().ToUpper()))
                .ToListAsync();

            return user;
        }

        public virtual async Task<IEnumerable<User>> SearchUserNameAsync(string search)
        {
            var user = await GetAll()
                .Where(g => g.UserName.Contains(search.Trim().ToUpper()))
                .ToListAsync();

            return user;
        }
    }
}
