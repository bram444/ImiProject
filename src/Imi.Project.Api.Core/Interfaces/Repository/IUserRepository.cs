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
        Task<IEnumerable<ApplicationUser>> SearchEmailAsync(string search);
        Task<IEnumerable<ApplicationUser>> SearchUserNameAsync(string search);
        Task<IEnumerable<ApplicationUser>> SearchFirstNameAsync(string search);
        Task<IEnumerable<ApplicationUser>> SearchLastNameAsync(string search);
        Task AddAsync(ApplicationUser entity);
        Task UpdateAsync(ApplicationUser entity);
        Task DeleteAsync(ApplicationUser entity);
    }
}