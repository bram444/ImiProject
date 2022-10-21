using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Imi.Project.Api.Core.Services
{
    public class GameGenreService : IGameGenreService
    {
        private readonly IGameGenreRepository _gameGenreRepository;

        private GameGenre CreateEntity(GameGenreResponseDto gameGenreResponseDto)
        {
            GameGenre gameGenre = new GameGenre
            {
                GameId = gameGenreResponseDto.GameId,
                GenreId = gameGenreResponseDto.GenreId,
            };
            return gameGenre;
        }

        private GameGenreResponseDto CreateDto(GameGenre gameGenre)
        {
            GameGenreResponseDto gameGenreResponseDto = new GameGenreResponseDto
            {
                GameId = gameGenre.GameId,
                GenreId = gameGenre.GenreId,
            };
            return gameGenreResponseDto;
        }

        public GameGenreService(IGameGenreRepository gameGenreRepository)
        {
            _gameGenreRepository = gameGenreRepository;

        }

        public async Task<ServiceResult<GameGenreResponseDto>> AddAsync(GameGenreResponseDto response)
        {
            var serviceResponse =new ServiceResult<GameGenreResponseDto>();

            try
            {
                serviceResponse.Result = CreateDto(await _gameGenreRepository.AddAsync(CreateEntity(response)));
            }
            catch(Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResult<GameGenreResponseDto>> DeleteAsync(GameGenreResponseDto response)
        {
            var serviceResponse = new ServiceResult<GameGenreResponseDto>();

            if (_gameGenreRepository.ListAllAsync().Result.Where(gg => gg.GenreId == response.GenreId && gg.GameId == response.GameId).Count() == 0)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add($"Many to many relationship does not exist");

                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _gameGenreRepository.DeleteAsync(CreateEntity(response)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public IQueryable<GameGenreResponseDto> GetAll()
        {
            List<GameGenreResponseDto> gameResponseDtos = new List<GameGenreResponseDto>();
            foreach (GameGenre entity in _gameGenreRepository.GetAll())
            {
                gameResponseDtos.Add(CreateDto(entity));
            }

            return gameResponseDtos.AsQueryable();
        }

        public async Task<IEnumerable<GameGenreResponseDto>> GetByGameIdAsync(Guid id)
        {
            List<GameGenreResponseDto> gameGenreResponseDtos = new List<GameGenreResponseDto>();

            foreach (GameGenre entity in await _gameGenreRepository.GetByGameIdAsync(id))
            {
                gameGenreResponseDtos.Add(CreateDto(entity));
            }

            return gameGenreResponseDtos;
        }

        public async Task<IEnumerable<GameGenreResponseDto>> GetByGenreIdAsync(Guid id)
        {
            List<GameGenreResponseDto> gameGenreResponseDtos = new List<GameGenreResponseDto>();
            foreach (GameGenre entity in await _gameGenreRepository.GetByGenreIdAsync(id))
            {
                gameGenreResponseDtos.Add(CreateDto(entity));
            }

            return gameGenreResponseDtos;
        }

        public async Task<IEnumerable<GameGenreResponseDto>> ListAllAsync()
        {
            List<GameGenreResponseDto> gameGenreResponseDtos = new List<GameGenreResponseDto>();
            foreach (GameGenre entity in await _gameGenreRepository.ListAllAsync())
            {
                gameGenreResponseDtos.Add(CreateDto(entity));
            }

            return gameGenreResponseDtos;
        }
    }
}

