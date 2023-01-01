using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IGameGenreRepository: IBaseGameMTMRepository<GameGenre>
    {
        //IQueryable<GameGenre> GetAll();
        //Task<IEnumerable<GameGenre>> ListAllAsync();
        Task<IEnumerable<GameGenre>> GetByGenreIdAsync(Guid id);
    }
}