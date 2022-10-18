using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> SearchAsync(string search);

        IQueryable<Genre> GetAll();
        Task<IEnumerable<Genre>> ListAllAsync();
        Task<Genre> GetByIdAsync(Guid id);
        Task<Genre> UpdateAsync(GenreResponseDto entity);
        Task<Genre> AddAsync(GenreResponseDto entity);
        Task<Genre> DeleteAsync(GenreResponseDto entity);
    }
}
