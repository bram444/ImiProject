using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.Genre;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGenreService:IBaseService<Genre>
    {
        Task<ServiceResultModel<Genre>> AddAsync(NewGenreModel entity);
        Task<ServiceResultModel<Genre>> UpdateAsync(UpdateGenreModel entity);
    }
}