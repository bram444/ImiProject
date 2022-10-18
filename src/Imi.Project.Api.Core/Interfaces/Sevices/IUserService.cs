using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
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
        Task<ServiceResult<User>> UpdateAsync(UserResponseDto entity);
        Task<ServiceResult<User>> AddAsync(UserResponseDto entity);
        Task<ServiceResult<User>> DeleteAsync(UserResponseDto entity);
    }
}
