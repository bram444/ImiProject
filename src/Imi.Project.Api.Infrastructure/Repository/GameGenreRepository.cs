using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class GameGenreRepository: BaseGameMTMRepository<GameGenre>, IGameGenreRepository
    {
        public GameGenreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        //public virtual IQueryable<GameGenre> GetAll()
        //{
        //    return _dbContext.Set<GameGenre>().AsQueryable();
        //}

        //public virtual async Task<IEnumerable<GameGenre>> ListAllAsync()
        //{
        //    try
        //    {
        //        return await _dbContext.GamesGenre.AsNoTracking().ToListAsync();
        //    } catch(Exception ex)
        //    {
        //        throw new Exception("Something went wrong when getting all GameGenre", ex.InnerException);
        //    }
        //}

        public async Task<IEnumerable<GameGenre>> GetByGenreIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.GamesGenre.Where(gg => gg.GenreId == id).AsNoTracking().ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong when getting all GameGenre with genre Id {id}", ex.InnerException);
            }
        }
    }
}