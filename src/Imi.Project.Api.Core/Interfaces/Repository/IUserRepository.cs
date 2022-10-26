using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<IEnumerable<ApplicationUser>> SearchUserNameAsync(string search);
        Task<IEnumerable<ApplicationUser>> SearchFirstNameAsync(string search);
        Task<IEnumerable<ApplicationUser>> SearchLastNameAsync(string search);

    }
}
