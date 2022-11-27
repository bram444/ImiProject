using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public interface IGenreService
    {
        Task<List<GenreInfo>> GetAllGenre();

        Task<GenreInfo> GenreById(Guid id);

        Task<GenreInfo> UpdateGenre(GenreInfo genre);

        Task<GenreInfo> DeleteGenre(Guid id);

        Task<GenreInfo> AddGenre(GenreInfo genre);

    }
}
