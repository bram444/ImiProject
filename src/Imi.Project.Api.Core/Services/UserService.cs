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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserGameRepository _userGameRepository;

        public UserService(IUserRepository userRepository, IUserGameRepository userGameRepository)
        {
            _userRepository = userRepository;
            _userGameRepository = userGameRepository;
        }

        private static ApplicationUser CreateEntity(UserResponseDto userResponseDto)
        {
            ApplicationUser user = new()
            {
                Id = userResponseDto.Id,
                Email = userResponseDto.Email,
                FirstName = userResponseDto.FirstName,
                LastName = userResponseDto.LastName,
                UserName = userResponseDto.UserName,
            };
            return user;
        }

        private async Task<List<Guid>> GetGameList(Guid userId)
        {
            IEnumerable<UserGame> userGames = await _userGameRepository.GetByUserIdAsync(userId);

            List<Guid> gameIds = new();

            foreach (UserGame userGame in userGames)
            {
                gameIds.Add(userGame.GameId);
            }

            return gameIds;
        }

        private static UserResponseDto CreateDto(ApplicationUser user, List<Guid> gameId)
        {
            UserResponseDto userResponseDto = new()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                GameId = gameId
            };
            return userResponseDto;
        }

        public async Task<ServiceResult<UserResponseDto>> AddAsync(UserResponseDto response)
        {
            ServiceResult<UserResponseDto> serviceResponse = new();

            try
            {
                serviceResponse.Result = CreateDto(await _userRepository.AddAsync(CreateEntity(response)), await GetGameList(response.Id));
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
            ServiceResult<UserResponseDto> serviceResponse = new();

            try
            {
                serviceResponse.Result = CreateDto(await _userRepository.DeleteAsync(await _userRepository.GetByIdAsync(id)), await GetGameList(id));
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
            List<UserResponseDto> userResponseDtos = new();

            foreach (ApplicationUser entity in _userRepository.GetAll())
            {
                IEnumerable<UserGame> userGames = _userGameRepository.GetByUserIdAsync(entity.Id).Result;

                List<Guid> gameIds = new();

                foreach (UserGame userGame in userGames)
                {
                    gameIds.Add(userGame.GameId);
                }

                userResponseDtos.Add(CreateDto(entity, gameIds));
            }

            return userResponseDtos.AsQueryable();
        }

        public async Task<UserResponseDto> GetByIdAsync(Guid id)
        {
            return CreateDto(await _userRepository.GetByIdAsync(id), await GetGameList(id));
        }

        public async Task<IEnumerable<UserResponseDto>> ListAllAsync()
        {
            List<UserResponseDto> userResponseDtos = new();
            foreach (ApplicationUser entity in await _userRepository.ListAllAsync())
            {
                userResponseDtos.Add(CreateDto(entity, await GetGameList(entity.Id)));
            }

            return userResponseDtos;
        }

        public async Task<IEnumerable<UserResponseDto>> SearchFirstNameAsync(string search)
        {
            List<UserResponseDto> userResponseList = new();
            foreach (ApplicationUser user in await _userRepository.SearchFirstNameAsync(search))
            {
                userResponseList.Add(CreateDto(user, await GetGameList(user.Id)));
            }

            return userResponseList;

        }
        public async Task<IEnumerable<UserResponseDto>> SearchLastNameAsync(string search)
        {
            List<UserResponseDto> userResponseList = new();
            foreach (ApplicationUser user in await _userRepository.SearchLastNameAsync(search))
            {
                userResponseList.Add(CreateDto(user, await GetGameList(user.Id)));
            }

            return userResponseList;
        }

        public async Task<IEnumerable<UserResponseDto>> SearchUserNameAsync(string search)
        {
            List<UserResponseDto> userResponseList = new();
            foreach (ApplicationUser user in await _userRepository.SearchUserNameAsync(search))
            {
                userResponseList.Add(CreateDto(user, await GetGameList(user.Id)));
            }

            return userResponseList;
        }

        public async Task<ServiceResult<UserResponseDto>> UpdateAsync(UserResponseDto response)
        {
            ServiceResult<UserResponseDto> serviceResponse = new();

            try
            {
                serviceResponse.Result = CreateDto(await _userRepository.UpdateAsync(CreateEntity(response)), await GetGameList(response.Id));
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
