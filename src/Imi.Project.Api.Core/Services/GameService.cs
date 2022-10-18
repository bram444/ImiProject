using Imi.Project.Api.Core.Dto;
using Imi.Project.Api.Core.Dto.Game;
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
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

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

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;

        }

        public async Task<Game> AddAsync(GameResponseDto entity)
        {
            return await _gameRepository.AddAsync(CreateEntity(entity));
        }

        public async Task<IEnumerable<Game>> GetByPublisherIdAsync(Guid id)
        {
            return await _gameRepository.GetByPublisherIdAsync(id);
        }

        public async Task<IEnumerable<Game>> SearchAsync(string search)
        {
            return await _gameRepository.SearchAsync(search);
        }

        public IQueryable<Game> GetAll()
        {
            return _gameRepository.GetAll();
        }

        public async Task<IEnumerable<Game>> ListAllAsync()
        {
            return await _gameRepository.ListAllAsync();
        }

        public async Task<Game> GetByIdAsync(Guid id)
        {
            return await _gameRepository.GetByIdAsync(id);
        }

        public async Task<Game> UpdateAsync(GameResponseDto entity)
        {
            return await _gameRepository.UpdateAsync(CreateEntity(entity));
        }

        public async Task<Game> DeleteAsync(GameResponseDto entity)
        {
            return await _gameRepository.DeleteAsync(CreateEntity(entity));
        }
    }
}
