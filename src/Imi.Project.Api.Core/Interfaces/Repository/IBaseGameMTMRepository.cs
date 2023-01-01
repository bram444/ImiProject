using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IBaseGameMTMRepository<MTM>
    {
        Task<IEnumerable<MTM>> GetByGameIdAsync(Guid id);
        Task<bool> DoesExistAsync(Expression<Func<MTM, bool>> predicate);
        Task AddAsync(MTM entity);
        Task DeleteAsync(MTM entity);
    }
}