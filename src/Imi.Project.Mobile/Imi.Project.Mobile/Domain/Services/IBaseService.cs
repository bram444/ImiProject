using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Update(T model);
        Task<T> Add(T model);
        Task<T> Delete(Guid id);
    }
}