using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IBaseService<T, NM, UM> where T : BaseEntity
    {
        Task<ServiceResultModel<IEnumerable<T>>> ListAllAsync();
        Task<ServiceResultModel<T>> GetByIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<T>>> SearchAsync(string search);
        Task<ServiceResultModel<T>> AddAsync(NM response);
        Task<ServiceResultModel<T>> UpdateAsync(UM response);
        Task<ServiceResultModel<T>> DeleteAsync(Guid id);
        ServiceResultModel<IEnumerable<T>> SetErrorList(Exception ex);
        ServiceResultModel<T> SetError(Exception ex);
    }
}