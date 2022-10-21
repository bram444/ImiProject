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
    public interface IGameService
    {
        Task<IEnumerable<GameResponseDto >> GetByPublisherIdAsync(Guid id);
        Task<IEnumerable<GameResponseDto>> SearchAsync(string search);

        IQueryable<GameResponseDto> GetAll();
        Task<IEnumerable<GameResponseDto>> ListAllAsync();
        Task<GameResponseDto> GetByIdAsync(Guid id);
        Task<ServiceResult<GameResponseDto>> UpdateAsync(GameResponseDto entity);
        Task<ServiceResult<GameResponseDto>> AddAsync(GameResponseDto entity);
        Task<ServiceResult<GameResponseDto>> DeleteAsync(Guid id);
    }
}
