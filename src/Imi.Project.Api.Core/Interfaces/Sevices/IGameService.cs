using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Entities;
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
        Task<Game> UpdateAsync(GameResponseDto entity);
        Task<Game> AddAsync(GameResponseDto entity);
        Task<Game> DeleteAsync(GameResponseDto entity);
    }
}
