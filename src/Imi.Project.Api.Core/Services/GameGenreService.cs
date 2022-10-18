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

        public async Task<GameGenre> AddAsync(GameGenreResponseDto entity)
        {

            return await _gameGenreRepository.AddAsync(CreateEntity(entity));

        }

        public async Task<GameGenre> DeleteAsync(GameGenreResponseDto entity)
        {

            return await _gameGenreRepository.DeleteAsync(CreateEntity(entity));

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

        public async Task<IEnumerable<GameGenre>> ListAllAsync()
        {
            return await _gameGenreRepository.ListAllAsync();
        }

        public async Task<GameGenre> UpdateAsync(GameGenreResponseDto entity)
        {

            return await _gameGenreRepository.UpdateAsync(CreateEntity(entity));

        }
    }
}

