using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetByPublisherIdAsync(Guid id);
        Task<IEnumerable<Game>> SearchAsync(string search);

        IQueryable<Game> GetAll();
        Task<IEnumerable<Game>> ListAllAsync();
        Task<Game> GetByIdAsync(Guid id);
        Task<ServiceResult<Game>> UpdateAsync(GameResponseDto entity);
        Task<ServiceResult<Game>> AddAsync(GameResponseDto entity);
        Task<ServiceResult<Game>> DeleteAsync(GameResponseDto entity);
    }
}
