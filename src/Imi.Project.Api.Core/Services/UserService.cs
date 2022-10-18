using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Dto.UserGame;
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

        private User CreateEntity(UserResponseDto userResponseDto)
        {
            User user = new User
            {
                Id = userResponseDto.Id,
                Email = userResponseDto.Email,
                FirstName = userResponseDto.FirstName,
             LastName= userResponseDto.LastName,
             UserName=userResponseDto.UserName,
            };
            return user;
        }

        public async Task<ServiceResult<User>> AddAsync(UserResponseDto entity)
        {
            var serviceResponse = new ServiceResult<User>();
            var userGameEntity = CreateEntity(entity);

            try
            {
                await _userRepository.AddAsync(userGameEntity);
                serviceResponse.Result = userGameEntity;
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResult<User>> DeleteAsync(UserResponseDto entity)
        {
            var serviceResponse = new ServiceResult<User>();
            var userEntity = CreateEntity(entity);

            try
            {
                await _userRepository.DeleteAsync(userEntity);
                serviceResponse.Result = userEntity;
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> ListAllAsync()
        {
            return await _userRepository.ListAllAsync();
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

        public async Task<ServiceResult<User>> UpdateAsync(UserResponseDto entity)
        {
            var serviceResponse = new ServiceResult<User>();
            var userEntity = CreateEntity(entity);

            try
            {
                await _userRepository.UpdateAsync(userEntity);
                serviceResponse.Result = userEntity;
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }
    }
}
