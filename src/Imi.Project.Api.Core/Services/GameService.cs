using Imi.Project.Api.Core.Dto;
using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPublisherRepository _publisherRepository;

        public GameService(IGameRepository gameRepository, IPublisherRepository publisherRepository)
        {
            _gameRepository = gameRepository;
            _publisherRepository = publisherRepository;
        }

        private Game CreateEntity(GameResponseDto gameResponseDto)
        {
            Game game= new Game
            {
                Id = gameResponseDto.Id,
                Name = gameResponseDto.Name,
                Price = gameResponseDto.Price,
                PublisherId = gameResponseDto.PublisherId
            };
            return game;
        }

        private GameResponseDto CreateDto(Game game)
        {
            GameResponseDto gameDto = new GameResponseDto
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                PublisherId = game.PublisherId
            };
            return gameDto;
        }


        public async Task<ServiceResult<GameResponseDto>> AddAsync(GameResponseDto response)
        {
            var serviceResponse = new ServiceResult<GameResponseDto>();

            if (await _publisherRepository.GetByIdAsync(response.Id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Game has an unexisting publisher");
                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _gameRepository.AddAsync(CreateEntity(response)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;

        }

        public async Task<IEnumerable<GameResponseDto>> GetByPublisherIdAsync(Guid id)
        {
            List<GameResponseDto> gameResponseDtos = new List<GameResponseDto>();
            foreach (Game entity in await _gameRepository.GetByPublisherIdAsync(id))
            {
                gameResponseDtos.Add(CreateDto(entity));
            }

            return gameResponseDtos;
        }

        public async Task<IEnumerable<GameResponseDto>> SearchAsync(string search)
        {
            List<GameResponseDto> gameResponseDtos = new List<GameResponseDto>();
            foreach (Game entity in await _gameRepository.SearchAsync(search))
            {
                gameResponseDtos.Add(CreateDto(entity));
            }

            return gameResponseDtos;
        }

        public IQueryable<GameResponseDto> GetAll()
        {
            List<GameResponseDto> gameResponseDtos = new List<GameResponseDto>();
            foreach (Game entity in _gameRepository.GetAll())
            {
                gameResponseDtos.Add(CreateDto(entity));
            }

            return gameResponseDtos.AsQueryable();
        }

        public async Task<IEnumerable<GameResponseDto>> ListAllAsync()
        {
            List<GameResponseDto> gameResponseDtos = new List<GameResponseDto>();
            foreach (Game entity in await _gameRepository.ListAllAsync())
            {
                gameResponseDtos.Add(CreateDto(entity));
            }

            return gameResponseDtos;
        }

        public async Task<GameResponseDto> GetByIdAsync(Guid id)
        {
            return CreateDto(await _gameRepository.GetByIdAsync(id));
        }

        public async Task<ServiceResult<GameResponseDto>> UpdateAsync(GameResponseDto response)
        {
            var serviceResponse = new ServiceResult<GameResponseDto>();

            if (await _gameRepository.GetByIdAsync(response.Id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Game does not exist");
                return serviceResponse;
            }

            if (await _publisherRepository.GetByIdAsync(response.Id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Game has an unexisting publisher");
                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _gameRepository.UpdateAsync(CreateEntity(response)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;

        }

        public async Task<ServiceResult<GameResponseDto>> DeleteAsync(Guid id)
        {
            var serviceResponse = new ServiceResult<GameResponseDto>();


            if (await _gameRepository.GetByIdAsync(id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Game does not exist");
                return serviceResponse;
            }

            try
            {


                serviceResponse.Result = CreateDto(await _gameRepository.DeleteAsync(await _gameRepository.GetByIdAsync(id)));
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
