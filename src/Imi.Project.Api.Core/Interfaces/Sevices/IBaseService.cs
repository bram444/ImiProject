using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<ServiceResultModel<IEnumerable<T>>> ListAllAsync();
        Task<ServiceResultModel<T>> GetByIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<T>>> SearchAsync(string search);
        Task<ServiceResultModel<T>> DeleteAsync(Guid id);
    }
}
