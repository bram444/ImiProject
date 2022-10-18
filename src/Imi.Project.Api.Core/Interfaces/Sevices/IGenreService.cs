using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
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
        Task<ServiceResult< Genre>> UpdateAsync(GenreResponseDto entity);
        Task<ServiceResult<Genre>> AddAsync(GenreResponseDto entity);
        Task<ServiceResult<Genre>> DeleteAsync(GenreResponseDto entity);
    }
}
