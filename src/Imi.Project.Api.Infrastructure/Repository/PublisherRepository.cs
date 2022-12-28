using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class PublisherRepository: BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}