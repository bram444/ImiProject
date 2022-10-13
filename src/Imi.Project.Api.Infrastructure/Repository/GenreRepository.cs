using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public virtual async Task<IEnumerable<Genre>> SearchAsync(string search)
        {
            var genre = await GetAll()
                .Where(g => g.Name.Contains(search.Trim().ToUpper()))
                .ToListAsync();

            return genre;
        }
    }
}
