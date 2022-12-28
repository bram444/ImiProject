using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class GenreRepository: BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}