using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> SearchUserNameAsync(string search);
        Task<IEnumerable<User>> SearchFirstNameAsync(string search);
        Task<IEnumerable<User>> SearchLastNameAsync(string search);

    }
}
