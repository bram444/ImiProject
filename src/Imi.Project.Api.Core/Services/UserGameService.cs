using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Dto.UserGame;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserGameService : IUserGameService
    {

        private readonly IUserGameRepository _userGameRepository;

        public UserGameService(IUserGameRepository userGameRepository)
        {
            _userGameRepository = userGameRepository;

        }

        private UserGame CreateEntity(UserGameResponseDto userGameResponseDto)
        {
            UserGame gameGenre = new UserGame
            {
                GameId = userGameResponseDto.GameId,
                 UserId = userGameResponseDto.UserId,
            };
            return gameGenre;
        }

        private UserGameResponseDto CreateDto(UserGame userGame)
        {
            UserGameResponseDto userGameResponseDto = new UserGameResponseDto
            {
                GameId = userGame.GameId,
                UserId = userGame.UserId,
            };
            return userGameResponseDto;
        }
        public async Task<ServiceResult<UserGameResponseDto>> AddAsync(UserGameResponseDto response)
        {
            var serviceResponse = new ServiceResult<UserGameResponseDto>();

            try
            {
                serviceResponse.Result = CreateDto(await _userGameRepository.AddAsync(CreateEntity(response)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResult<UserGameResponseDto>> DeleteAsync(UserGameResponseDto response)
        {
            var serviceResponse = new ServiceResult<UserGameResponseDto>();

            if (_userGameRepository.ListAllAsync().Result.Where(gg => gg.UserId == response.UserId && gg.GameId == response.GameId).Count() == 0)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add($"Many to many relationship does not exist");

                return serviceResponse;
            }

            try
            {
                await _userGameRepository.DeleteAsync(CreateEntity(response));
                serviceResponse.Result = response;
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public IQueryable<UserGameResponseDto> GetAll()
        {
            List<UserGameResponseDto> userGameResponseDtos = new List<UserGameResponseDto>();
            foreach (UserGame entity in _userGameRepository.GetAll())
            {
                userGameResponseDtos.Add(CreateDto(entity));
            }

            return userGameResponseDtos.AsQueryable();
        }

        public async Task<IEnumerable<UserGameResponseDto>> GetByGameIdAsync(Guid id)
        {
            List<UserGameResponseDto> userGameResponseDtos = new List<UserGameResponseDto>();

            foreach (UserGame entity in await _userGameRepository.GetByGameIdAsync(id))
            {
                userGameResponseDtos.Add(CreateDto(entity));
            }

            return userGameResponseDtos;
        }

        public async Task<IEnumerable<UserGameResponseDto>> GetByUserIdAsync(Guid id)
        {
            List<UserGameResponseDto> userGameResponseDtos = new List<UserGameResponseDto>();
            foreach (UserGame entity in await _userGameRepository.GetByUserIdAsync(id))
            {
                userGameResponseDtos.Add(CreateDto(entity));
            }

            return userGameResponseDtos;
        }

        public async Task<IEnumerable<UserGameResponseDto>> ListAllAsync()
        {
            List<UserGameResponseDto> userResponseDtos = new List<UserGameResponseDto>();
            foreach (UserGame entity in await _userGameRepository.ListAllAsync())
            {
                userResponseDtos.Add(CreateDto(entity));
            }

            return userResponseDtos;
        }
    }
}
