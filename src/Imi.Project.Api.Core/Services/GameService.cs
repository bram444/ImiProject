using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapping;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GameService:BaseService<Game,IGameRepository>, IGameService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;

        public GameService(IGameRepository gameRepository, IPublisherRepository publisherRepository, IGenreRepository genreRepository):base(gameRepository)
        {
            _publisherRepository = publisherRepository;
            _genreRepository = genreRepository;
        }

        public async Task<ServiceResultModel<IEnumerable<Game>>> GetByPublisherIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<Game>> result = new();

            try
            {
                result.Data = await _itemRepository.GetFilteredListAsync(g=>g.PublisherId==id);
                return result;
            } catch(Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                return result;
            }
        }

        public async Task<ServiceResultModel<Game>> AddAsync(NewGameModel entity)
        {
            ServiceResultModel<Game> result = new();

            try
            {
                if(!await _publisherRepository.DoesExistAsync(entity.PublisherId))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Publisher {entity.PublisherId} doesn't exist"));
                }

                if(await _itemRepository.DoesExistAsync(game => game.Name == entity.Name))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Game with name {entity.Name} already exists"));
                }

                foreach(var id in entity.GenreId)
                {
                    if(!await _genreRepository.DoesExistAsync(id))
                    {
                        result.IsSuccess = false;
                        result.ValidationErrors.Add(new ValidationResult($"Genre {id} does not exist"));
                    }
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                var gameEntity = entity.MapToEntity();

                await _itemRepository.AddAsync(gameEntity);
                result.Data = gameEntity;
                return result;
            } catch(Exception ex)
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

        public async Task<ServiceResultModel<Game>> UpdateAsync(UpdateGameModel entity)
        {
            ServiceResultModel<Game> result = new();

            try
            {
                if(!await _itemRepository.DoesExistAsync(entity.Id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Game does not exist"));
                }

                if(!await _publisherRepository.DoesExistAsync(entity.PublisherId))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Publisher {entity.PublisherId} doesn't exist"));
                }

                if(await _itemRepository.DoesExistAsync(game => game.Name == entity.Name && (game.Id != entity.Id)))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Game with name {entity.Name} already exists"));
                }

                foreach(var id in entity.GenreId)
                {
                    if(!await _genreRepository.DoesExistAsync(id))
                    {
                        result.IsSuccess = false;
                        result.ValidationErrors.Add(new ValidationResult($"Genre {id} does not exist"));
                    }
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                var game = entity.MapToEntity();

                await _itemRepository.UpdateAsync(game);

                result.Data = game;
                return result;

            } catch(Exception ex)
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