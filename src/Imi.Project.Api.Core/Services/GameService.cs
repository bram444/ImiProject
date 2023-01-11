using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapper;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GameService: BaseService<Game, IGameRepository, NewGameModel, UpdateGameModel>, IGameService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;

        public GameService(IGameRepository gameRepository, IPublisherRepository publisherRepository, IGenreRepository genreRepository) : base(gameRepository)
        {
            _publisherRepository = publisherRepository;
            _genreRepository = genreRepository;
        }

        public async Task<ServiceResultModel<IEnumerable<Game>>> GetByPublisherIdAsync(Guid id)
        {
            try
            {
                return new ServiceResultModel<IEnumerable<Game>>
                {
                    Data = await _itemRepository.GetFilteredListAsync(g => g.PublisherId == id)
                };
            } catch(Exception ex)
            {
                return SetErrorList(ex);
            }
        }

        public override async Task<ServiceResultModel<Game>> AddAsync(NewGameModel entity)
        {
            try
            {
                ServiceResultModel<Game> result = await ErrorCheckAdd(entity);

                if(result.IsSuccess)
                {
                    await _itemRepository.AddAsync(result.Data);
                }

                return result;

            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }

        public override async Task<ServiceResultModel<Game>> UpdateAsync(UpdateGameModel entity)
        {
            try
            {
                ServiceResultModel<Game> result = await ErrorCheckUpdate(entity);

                if(result.IsSuccess)
                {
                    await _itemRepository.UpdateAsync(result.Data);
                }

                return result;

            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }

        private async Task<ServiceResultModel<Game>> ErrorCheckAdd(NewGameModel newGameModel)
        {
            ServiceResultModel<Game> result = new()
            {
                Data = newGameModel.MapToEntity()
            };

            foreach(Guid id in newGameModel.GenreId)
            {
                if(!await _genreRepository.DoesExistAsync(id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Genre {id} does not exist"));
                }
            }

            return await ErrorCheck(result);
        }

        private async Task<ServiceResultModel<Game>> ErrorCheckUpdate(UpdateGameModel updateGameModel)
        {
            ServiceResultModel<Game> result = new()
            {
                Data = updateGameModel.MapToEntity()
            };

            foreach(Guid id in updateGameModel.GenreId)
            {
                if(!await _genreRepository.DoesExistAsync(id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Genre {id} does not exist"));
                }
            }

            if(!await _itemRepository.DoesExistAsync(updateGameModel.Id))
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult("Game does not exist"));
            }

            return await ErrorCheck(result);
        }

        private async Task<ServiceResultModel<Game>> ErrorCheck(ServiceResultModel<Game> result)
        {
            if(!await _publisherRepository.DoesExistAsync(result.Data.PublisherId))
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult($"Publisher {result.Data.PublisherId} doesn't exist"));
            }

            if(await _itemRepository.DoesExistAsync(game => game.Name == result.Data.Name && game.Id != result.Data.Id))
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult($"Game with name {result.Data.Name} already exists"));
            }

            return result;
        }
    }
}