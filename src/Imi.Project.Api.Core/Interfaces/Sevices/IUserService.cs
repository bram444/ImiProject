using Imi.Project.Api.Core.Dto.Genre;
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
        Task<IEnumerable<UserResponseDto>> SearchUserNameAsync(string search);
        Task<IEnumerable<UserResponseDto>> SearchFirstNameAsync(string search);
        Task<IEnumerable<UserResponseDto>> SearchLastNameAsync(string search);

        IQueryable<UserResponseDto> GetAll();
        Task<IEnumerable<UserResponseDto>> ListAllAsync();
        Task<UserResponseDto> GetByIdAsync(Guid id);
        Task<ServiceResult<UserResponseDto>> UpdateAsync(UserResponseDto response);
        Task<ServiceResult<UserResponseDto>> AddAsync(UserResponseDto response);
        Task<ServiceResult<UserResponseDto>> DeleteAsync(Guid id);
    }
}
