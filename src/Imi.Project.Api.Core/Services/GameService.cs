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
        private readonly IGameGenreRepository _gameGenreRepository;

        public GameService(IGameRepository gameRepository, IPublisherRepository publisherRepository, IGameGenreRepository gameGenreRepository)
        {
            _gameRepository = gameRepository;
            _publisherRepository = publisherRepository;
            _gameGenreRepository = gameGenreRepository;
        }

        private static Game CreateEntity(GameResponseDto gameResponseDto)
        {
            Game game = new()
            {
                Id = gameResponseDto.Id,
                Name = gameResponseDto.Name,
                Price = gameResponseDto.Price,
                PublisherId = gameResponseDto.PublisherId
            };
            return game;
        }

        private async Task<List<Guid>> GetGenreList(Guid gameId)
        {
            IEnumerable<GameGenre> gameGenres = await _gameGenreRepository.GetByGameIdAsync(gameId);

            List<Guid> genreIds = new();


            foreach (GameGenre gameGenre in gameGenres)
            {
                genreIds.Add(gameGenre.GenreId);
            }

            return genreIds;
        }

        private static GameResponseDto CreateDto(Game game, List<Guid> genreId)
        {
            GameResponseDto gameDto = new()
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                PublisherId = game.PublisherId,
                GenreId = genreId
            };
            return gameDto;
        }

        public async Task<ServiceResult<GameResponseDto>> AddAsync(GameResponseDto response)
        {
            ServiceResult<GameResponseDto> serviceResponse = new();

            if (await _publisherRepository.GetByIdAsync(response.PublisherId) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Game has an unexisting publisher");
                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _gameRepository.AddAsync(CreateEntity(response)), await GetGenreList(response.Id));
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
            List<GameResponseDto> gameResponseDtos = new();
            foreach (Game entity in await _gameRepository.GetByPublisherIdAsync(id))
            {
                gameResponseDtos.Add(CreateDto(entity, await GetGenreList(id)));
            }

            return gameResponseDtos;
        }

        public async Task<IEnumerable<GameResponseDto>> SearchAsync(string search)
        {
            List<GameResponseDto> gameResponseDtos = new();
            foreach (Game entity in await _gameRepository.SearchAsync(search))
            {
                gameResponseDtos.Add(CreateDto(entity, await GetGenreList(entity.Id)));
            }

            return gameResponseDtos;
        }

        public IQueryable<GameResponseDto> GetAll()
        {
            List<GameResponseDto> gameResponseDtos = new();
            foreach (Game entity in _gameRepository.GetAll())
            {
                IEnumerable<GameGenre> gameGenresIEnum = _gameGenreRepository.GetByGameIdAsync(entity.Id).Result;

                List<Guid> genreIds = new();

                foreach (GameGenre gameGenre in gameGenresIEnum)
                {
                    genreIds.Add(gameGenre.GenreId);
                }

                gameResponseDtos.Add(CreateDto(entity, genreIds));
            }

            return gameResponseDtos.AsQueryable();
        }

        public async Task<IEnumerable<GameResponseDto>> ListAllAsync()
        {
            List<GameResponseDto> gameResponseDtos = new();
            foreach (Game entity in await _gameRepository.ListAllAsync())
            {
                gameResponseDtos.Add(CreateDto(entity, await GetGenreList(entity.Id)));
            }

            return gameResponseDtos;
        }

        public async Task<GameResponseDto> GetByIdAsync(Guid id)
        {
            return CreateDto(await _gameRepository.GetByIdAsync(id), await GetGenreList(id));
        }

        public async Task<ServiceResult<GameResponseDto>> UpdateAsync(GameResponseDto response)
        {
            ServiceResult<GameResponseDto> serviceResponse = new();

            if (await _gameRepository.GetByIdAsync(response.Id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Game does not exist");
                return serviceResponse;
            }

            if (await _publisherRepository.GetByIdAsync(response.PublisherId) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Game has an unexisting publisher");
                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _gameRepository.UpdateAsync(CreateEntity(response)), await GetGenreList(response.Id));
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
            ServiceResult<GameResponseDto> serviceResponse = new();

            if (await _gameRepository.GetByIdAsync(id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Game does not exist");
                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _gameRepository.DeleteAsync(await _gameRepository.GetByIdAsync(id)), await GetGenreList(id));
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