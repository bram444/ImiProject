using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GenreInfoService: BaseService<GenreInfo>, IGenreService
    {
        public GenreInfoService(CustomHttpClient customHttpClient) :base(customHttpClient,"/api/Genre")
        {
        }
    }
}