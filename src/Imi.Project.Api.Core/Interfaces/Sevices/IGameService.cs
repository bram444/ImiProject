using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IGameService
    {
        Task<ServiceResultModel<IEnumerable<Game>>> ListAllAsync();
        Task<ServiceResultModel<Game>> GetByIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<Game>>> GetByPublisherIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<Game>>> SearchAsync(string search);
        Task<ServiceResultModel<Game>> AddAsync(GameModel entity);
        Task<ServiceResultModel<Game>> UpdateAsync(GameModel entity);
        Task<ServiceResultModel<Game>> DeleteAsync(Guid id);
    }
}