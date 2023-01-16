using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public interface IBaseService<T, N, U>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<ApiResponse<T>> Update(U model);
        Task<ApiResponse<T>> Add(N model);
        Task<ApiResponse<T>> Delete(Guid id);
        void SetToken(string token);

    }
}