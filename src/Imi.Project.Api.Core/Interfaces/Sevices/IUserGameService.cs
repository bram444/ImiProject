using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Dto.UserGame;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IUserGameService
    {
        IQueryable<UserGameResponseDto> GetAll();
        Task<IEnumerable<UserGameResponseDto>> ListAllAsync();
        Task<IEnumerable<UserGameResponseDto>> GetByGameIdAsync(Guid id);
        Task<IEnumerable<UserGameResponseDto>> GetByUserIdAsync(Guid id);

        Task<ServiceResult<UserGameResponseDto>> AddAsync(UserGameResponseDto response);
        Task<ServiceResult<UserGameResponseDto>> DeleteAsync(UserGameResponseDto response);
    }
}
