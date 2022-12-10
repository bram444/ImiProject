using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IGameRepository: IBaseRepository<Game>
    {
        Task<IEnumerable<Game>> GetByPublisherIdAsync(Guid id);
        Task<IEnumerable<Game>> SearchAsync(string search);
    }
}