using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> AddAsync(UserResponseDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(UserResponseDto entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> SearchFirstNameAsync(string search)
        {
            return await _userRepository.SearchFirstNameAsync(search);
        }

        public async Task<IEnumerable<User>> SearchLastNameAsync(string search)
        {
            return await _userRepository.SearchLastNameAsync(search);

        }

        public async Task<IEnumerable<User>> SearchUserNameAsync(string search)
        {
            return await _userRepository.SearchUserNameAsync(search);
        }

        public Task<User> UpdateAsync(UserResponseDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
