using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IGenreRepository: IBaseRepository<Genre>
    {
        //public bool DoesListExist(ICollection<Guid> ids);

        //Task<IEnumerable<Guid>> GetNonExistend(IEnumerable<Guid> ids);
    }
}