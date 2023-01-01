using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IUserGameRepository: IBaseGameMTMRepository<UserGame>
    {
        //IQueryable<UserGame> GetAll();
        //Task<IEnumerable<UserGame>> ListAllAsync();
        Task<IEnumerable<UserGame>> GetByUserIdAsync(Guid id);
    }
}