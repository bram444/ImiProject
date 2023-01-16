using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GenreInfoService: BaseService<GenreInfo, NewGenreInfo, UpdateGenreInfo>, IGenreService
    {
        public GenreInfoService(CustomHttpClient customHttpClient) : base(customHttpClient, "/api/Genre")
        {
        }
    }
}