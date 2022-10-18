using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> SearchUserNameAsync(string search);
        Task<IEnumerable<User>> SearchFirstNameAsync(string search);
        Task<IEnumerable<User>> SearchLastNameAsync(string search);

        IQueryable<User> GetAll();
        Task<IEnumerable<User>> ListAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> UpdateAsync(UserResponseDto entity);
        Task<User> AddAsync(UserResponseDto entity);
        Task<User> DeleteAsync(UserResponseDto entity);
    }
}
