using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IBaseGameMTMService<MTM, TM> where MTM : BaseGameMTM
        where TM : BaseGameMTMModel
    {
        //Task<ServiceResultModel<IEnumerable<T>>> ListAllAsync();
        Task<ServiceResultModel<IEnumerable<MTM>>> GetByGameIdAsync(Guid id);
        Task<ServiceResultModel<MTM>> AddAsync(TM TModel);
        Task<ServiceResultModel<MTM>> DeleteAsync(TM TModel);
        ServiceResultModel<MTM> SetError(Exception ex);
        ServiceResultModel<IEnumerable<MTM>> SetErrorList(Exception ex);
    }
}