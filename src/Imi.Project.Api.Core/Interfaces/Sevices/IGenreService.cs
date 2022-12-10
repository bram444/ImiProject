using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseDto>> SearchAsync(string search);
        IQueryable<GenreResponseDto> GetAll();
        Task<IEnumerable<GenreResponseDto>> ListAllAsync();
        Task<GenreResponseDto> GetByIdAsync(Guid id);
        Task<ServiceResult<GenreResponseDto>> UpdateAsync(GenreResponseDto entity);
        Task<ServiceResult<GenreResponseDto>> AddAsync(GenreResponseDto entity);
        Task<ServiceResult<GenreResponseDto>> DeleteAsync(Guid id);
    }
}