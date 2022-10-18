using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> SearchUserNameAsync(string search);
        Task<IEnumerable<User>> SearchFirstNameAsync(string search);
        Task<IEnumerable<User>> SearchLastNameAsync(string search);

    }
}
