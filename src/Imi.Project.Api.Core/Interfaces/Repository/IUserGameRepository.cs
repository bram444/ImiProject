using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IUserGameRepository
    {
        IQueryable<UserGame> GetAll();
        Task<IEnumerable<UserGame>> ListAllAsync();
        Task<IEnumerable<UserGame>> GetByGameIdAsync(Guid id);
        Task<IEnumerable<UserGame>> GetByUserIdAsync(Guid id);
        Task AddAsync(UserGame entity);
        Task DeleteAsync(UserGame entity);
    }
}