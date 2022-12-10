using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IGenreRepository: IBaseRepository<Genre>
    {
        Task<IEnumerable<Genre>> SearchAsync(string search);
    }
}