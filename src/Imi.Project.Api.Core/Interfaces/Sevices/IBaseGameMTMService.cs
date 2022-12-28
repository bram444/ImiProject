using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IBaseGameMTMService<T> where T : BaseGameMTM
    {
        Task<ServiceResultModel<IEnumerable<T>>> ListAllAsync();
        Task<ServiceResultModel<IEnumerable<T>>> GetByGameIdAsync(Guid id);
    }
}
