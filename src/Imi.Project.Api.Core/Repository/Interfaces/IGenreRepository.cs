using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Repository.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<IEnumerable<Genre>> SearchAsync(string search);
    }
}
