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
                LastName = userResponseDto.LastName,
                UserName = userResponseDto.UserName,
            };
            return user;
        }

        private UserResponseDto CreateDto(User user)
        {
            UserResponseDto userResponseDto = new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
            };
            return userResponseDto;
        }

        public async Task<ServiceResult<UserResponseDto>> AddAsync(UserResponseDto response)
        {
            var serviceResponse = new ServiceResult<UserResponseDto>();

            try
            {
                serviceResponse.Result = CreateDto(await _userRepository.AddAsync(CreateEntity(response)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResult<UserResponseDto>> DeleteAsync(Guid id)
        {
            var serviceResponse = new ServiceResult<UserResponseDto>();

            try
            {
                serviceResponse.Result = CreateDto(await _userRepository.DeleteAsync(await _userRepository.GetByIdAsync(id)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;

        }

        public IQueryable<UserResponseDto> GetAll()
        {
            List<UserResponseDto> userResponseDtos = new List<UserResponseDto>();
            foreach(User entity in _userRepository.GetAll())
            {
                userResponseDtos.Add(CreateDto(entity));
            }

            return userResponseDtos.AsQueryable();
        }

        public async Task<UserResponseDto> GetByIdAsync(Guid id)
        {
            return CreateDto(await _userRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<UserResponseDto>> ListAllAsync()
        {
            List<UserResponseDto> userResponseDtos = new List<UserResponseDto>();
            foreach (User entity in await _userRepository.ListAllAsync())
            {
                userResponseDtos.Add(CreateDto(entity));
            }

            return userResponseDtos;
        }

        public async Task<IEnumerable<UserResponseDto>> SearchFirstNameAsync(string search)
        {
            List<UserResponseDto> userResponseList = new List<UserResponseDto>(); 
            foreach(User user in await _userRepository.SearchFirstNameAsync(search))
            {
                userResponseList.Add(CreateDto(user));
            }

            return userResponseList;

        }
        public async Task<IEnumerable<UserResponseDto>> SearchLastNameAsync(string search)
        {
            List<UserResponseDto> userResponseList = new List<UserResponseDto>();
            foreach (User user in await _userRepository.SearchLastNameAsync(search))
            {
                userResponseList.Add(CreateDto(user));
            }

            return userResponseList;
        }

        public async Task<IEnumerable<UserResponseDto>> SearchUserNameAsync(string search)
        {
            List<UserResponseDto> userResponseList = new List<UserResponseDto>();
            foreach (User user in await _userRepository.SearchUserNameAsync(search))
            {
                userResponseList.Add(CreateDto(user));
            }

            return userResponseList;
        }

        public async Task<ServiceResult<UserResponseDto>> UpdateAsync(UserResponseDto response)
        {
            var serviceResponse = new ServiceResult<UserResponseDto>();

            try
            {
                serviceResponse.Result = CreateDto( await _userRepository.UpdateAsync(CreateEntity(response)));
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
