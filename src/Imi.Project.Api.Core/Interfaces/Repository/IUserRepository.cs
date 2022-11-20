using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        IQueryable<ApplicationUser> GetAll();
        Task<IEnumerable<ApplicationUser>> ListAllAsync();
        Task<ApplicationUser> GetByIdAsync(Guid id);
        Task<ApplicationUser> UpdateAsync(ApplicationUser entity);
        Task<ApplicationUser> AddAsync(ApplicationUser entity);
        Task<ApplicationUser> DeleteAsync(ApplicationUser entity);

        Task<IEnumerable<ApplicationUser>> SearchUserNameAsync(string search);
        Task<IEnumerable<ApplicationUser>> SearchFirstNameAsync(string search);
        Task<IEnumerable<ApplicationUser>> SearchLastNameAsync(string search);

    }
}