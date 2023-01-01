using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Infrastructure.Data;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class GameRepository: BaseRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}