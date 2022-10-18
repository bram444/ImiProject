using Imi.Project.Api.Core.Dto.UserGame;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IUserGameService
    {
        IQueryable<UserGame> GetAll();
        Task<IEnumerable<UserGame>> ListAllAsync();
        Task<UserGame> GetByGameIdAsync(Guid id);
        Task<UserGame> GetByUserIdAsync(Guid id);

        Task<UserGame> UpdateAsync(UserGameResponseDto entity);
        Task<UserGame> AddAsync(UserGameResponseDto entity);
        Task<UserGame> DeleteAsync(UserGameResponseDto entity);
    }
}
