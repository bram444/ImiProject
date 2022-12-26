using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;

        public GameService(IGameRepository gameRepository, IPublisherRepository publisherRepository, IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _publisherRepository = publisherRepository;
            _genreRepository = genreRepository;
        }
        public async Task<ServiceResultModel<Game>> AddAsync(GameModel entity)
        {
            ServiceResultModel<Game> result = new()
            {
                IsSuccess = true
            };

            try
            {
                Game game = new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Price = entity.Price,
                    PublisherId = entity.PublisherId
                };

                if(await _publisherRepository.GetByIdAsync(entity.PublisherId) == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Publisher {entity.PublisherId} doesn't exist"));
                }

                var allGenres = await _genreRepository.ListAllAsync();

                foreach(var genreId in entity.GenreId)
                {
                    if(!allGenres.Any(gen => gen.Id == genreId))
                    {
                        result.IsSuccess = false;
                        result.ValidationErrors.Add(new ValidationResult($"Genre {genreId} doesn't exist"));
                    }
                }

                var allgames= await _gameRepository.SearchAsync(entity.Name);

                if(allgames.Any(game => (game.Name == entity.Name) && (game.Id != entity.Id)) && allgames.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Game with name {entity.Name} already exists"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                await _gameRepository.AddAsync(game);
                result.IsSuccess = true;
                result.Data = game;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                if(ex.InnerException != null)
                {
                    result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
                }
                return result;
            }
        }

        public async Task<ServiceResultModel<IEnumerable<Game>>> GetByPublisherIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<Game>> result = new();

            List<Game> gameList = new();

            try
            {
                foreach (Game entity in await _gameRepository.GetByPublisherIdAsync(id))
                {

                    gameList.Add(entity);
                }

                result.IsSuccess = true;
                result.Data = gameList;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                return result;
            }
        }

        public async Task<ServiceResultModel<IEnumerable<Game>>> SearchAsync(string search)
        {
            ServiceResultModel<IEnumerable<Game>> result = new();
            try
            {

                List<Game> gameList = new();
                foreach (Game entity in await _gameRepository.SearchAsync(search))
                {
                    gameList.Add(entity);
                }

                result.IsSuccess = true;
                result.Data = gameList;
                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));

                return result;
            }
        }

        public async Task<ServiceResultModel<IEnumerable<Game>>> ListAllAsync()
        {
            List<Game> gameModels = new();
            ServiceResultModel<IEnumerable<Game>> result = new();

            try
            {
                foreach (Game entity in await _gameRepository.ListAllAsync())
                {
                    gameModels.Add(entity);
                }

                result.Data = gameModels;
                result.IsSuccess = true;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                if(ex.InnerException != null)
                {
                    result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
                }
                return result;
            }

        }

        public async Task<ServiceResultModel<Game>> GetByIdAsync(Guid id)
        {
            ServiceResultModel<Game> result = new();
            try
            {
                Game game = await _gameRepository.GetByIdAsync(id);

                if(game==null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Game soes not exist"));
                    return result;
                }

                result.IsSuccess = true;
                result.Data = game;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                if(ex.InnerException != null)
                {
                    result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
                }
                return result;
            }
        }

        public async Task<ServiceResultModel<Game>> UpdateAsync(GameModel entity)
        {
            ServiceResultModel<Game> result = new();

            try
            {
                if (await _gameRepository.GetByIdAsync(entity.Id) == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Game does not exist"));
                }

                if (await _publisherRepository.GetByIdAsync(entity.PublisherId) == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Publisher {entity.PublisherId} doesn't exist"));
                }

                var allgames = await _gameRepository.SearchAsync(entity.Name);

                if(allgames.Any(game => (game.Name == entity.Name) && (game.Id != entity.Id)) && allgames.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Game with name {entity.Name} already exists"));
                }

                var allGenres = await _genreRepository.ListAllAsync();

                foreach(var genreId in entity.GenreId)
                {
                    if(!allGenres.Any(gen => gen.Id == genreId))
                    {
                        result.IsSuccess = false;
                        result.ValidationErrors.Add(new ValidationResult($"Genre {genreId} doesn't exist"));
                    }
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                await _gameRepository.UpdateAsync(new Game
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Price = entity.Price,
                    PublisherId = entity.PublisherId
                });

                result.Data = new Game
                {
                    Id = entity.Id,
                    LastEditedOn = DateTime.Now,
                    Name = entity.Name,
                    Price = entity.Price,
                    PublisherId = entity.PublisherId
                };
                result.IsSuccess = true;
                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                if(ex.InnerException != null)
                {
                    result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
                }
                return result;
            }
        }

        public async Task<ServiceResultModel<Game>> DeleteAsync(Guid id)
        {
            ServiceResultModel<Game> result = new();

            if (await _gameRepository.GetByIdAsync(id) == null)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult("Game does not exist"));
                return result;
            }

            try
            {
                await _gameRepository.DeleteAsync(await _gameRepository.GetByIdAsync(id));
                result.IsSuccess = true;
                result.Data = new();
                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                if(ex.InnerException != null)
                {
                    result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
                }
                return result;
            }
        }
    }
}