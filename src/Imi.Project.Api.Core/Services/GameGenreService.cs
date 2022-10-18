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


        public GameGenreService(IGameGenreRepository gameGenreRepository)
        {
            _gameGenreRepository = gameGenreRepository;
        }

        public async Task<ServiceResult<GameGenre>> AddAsync(GameGenreResponseDto entity)
        {
            var serviceResponse =new ServiceResult<GameGenre>();
            var gameGenreEntity = CreateEntity(entity);

            try
            {
                await _gameGenreRepository.AddAsync(gameGenreEntity);
                serviceResponse.Result = gameGenreEntity;
            }
            catch(Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResult<GameGenre>> DeleteAsync(GameGenreResponseDto entity)
        {
            var serviceResponse = new ServiceResult<GameGenre>();
            var gameGenreEntity = CreateEntity(entity);

            try
            {
                await _gameGenreRepository.DeleteAsync(gameGenreEntity);
                serviceResponse.Result = gameGenreEntity;
            }
            catch(Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }

                return serviceResponse;

        }

        public IQueryable<GameGenre> GetAll()
        {
            return _gameGenreRepository.GetAll();
        }

        public async Task<GameGenre> GetByGameIdAsync(Guid id)
        {

            return await _gameGenreRepository.GetByGameIdAsync(id);

        }

        public async Task<GameGenre> GetByGenreIdAsync(Guid id)
        {
            return await _gameGenreRepository.GetByGenreIdAsync(id);

        }

        public async Task<IEnumerable< GameGenre>> ListAllAsync()
        {


            return await _gameGenreRepository.ListAllAsync();
        }

        public async Task<ServiceResult<GameGenre>> UpdateAsync(GameGenreResponseDto entity)
        {

            var serviceResponse = new ServiceResult<GameGenre>();
            var gameGenreEntity = CreateEntity(entity);

            try
            {
                await _gameGenreRepository.UpdateAsync(gameGenreEntity);
                serviceResponse.Result = gameGenreEntity;
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

