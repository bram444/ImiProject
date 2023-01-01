using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Genre;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGenreService:IBaseService<Genre, NewGenreModel, UpdateGenreModel>
    {
    }
}