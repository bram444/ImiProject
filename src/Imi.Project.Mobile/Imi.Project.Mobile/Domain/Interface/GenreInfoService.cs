using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;

namespace Imi.Project.Mobile.Domain.Interface
{
    public class GenreInfoService: BaseService<GenreInfo, NewGenreInfo, UpdateGenreInfo>, IGenreService
    {
        public GenreInfoService(CustomHttpClient customHttpClient) : base(customHttpClient, "/api/Genre")
        {
        }
    }
}