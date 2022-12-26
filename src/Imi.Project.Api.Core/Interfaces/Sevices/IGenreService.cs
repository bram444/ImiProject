using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGenreService
    {

        Task<ServiceResultModel<IEnumerable<Genre>>> ListAllAsync();
        Task<ServiceResultModel<Genre>> GetByIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<Genre>>> SearchAsync(string search);
        Task<ServiceResultModel<Genre>> AddAsync(GenreModel entity);
        Task<ServiceResultModel<Genre>> UpdateAsync(GenreModel entity);
        Task<ServiceResultModel<Genre>> DeleteAsync(Guid id);
    }
}