using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class GenreRepository: BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IEnumerable<Genre>> SearchAsync(string search)
        {
            try
            { 
            return await GetAll()
                .Where(g => g.Name.Contains(search.Trim().ToUpper())).AsNoTracking()
                .ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong with getting genre with name {search}", ex.InnerException);
            }
        }
    }
}