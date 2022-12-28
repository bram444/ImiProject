using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapping;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.GameGenre;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GameGenreService: IGameGenreService
    {
        private readonly IGameGenreRepository _gameGenreRepository;

        public GameGenreService(IGameGenreRepository gameGenreRepository)
        {
            _gameGenreRepository = gameGenreRepository;
        }

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> ListAllAsync()
        {
            ServiceResultModel<IEnumerable<GameGenre>> result = new();

            try
            {
                result.Data = await _gameGenreRepository.ListAllAsync();
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

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> GetByGameIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<GameGenre>> result = new();

            try
            {
                result.Data = await _gameGenreRepository.GetByGameIdAsync(id);
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

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> GetByGenreIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<GameGenre>> result = new();

            try
            {
                result.Data = await _gameGenreRepository.GetByGenreIdAsync(id);
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

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> EditGameGenreAsync(UpdateGameGenreModel updateGameGenreModel)
        {
            var gameGenreIenum = await GetByGameIdAsync(updateGameGenreModel.GameId);

            if(!gameGenreIenum.IsSuccess)
            {
                return gameGenreIenum;
            }

            List<GameGenreModel> updateGameGenre = new();

            foreach(Guid genreId in updateGameGenreModel.GenreIds.Distinct())
            {
                updateGameGenre.Add(GameGenreEntityMapper.GameGenreModelMapper(genreId, updateGameGenreModel.GameId));
            }

            var toDeleteGenre = gameGenreIenum.Data.MapToModel().Except(updateGameGenre).ToList();
            foreach(var deleteGenre in toDeleteGenre)
            {
                ServiceResultModel<GameGenre> result = await DeleteAsync(deleteGenre);
                if(!result.IsSuccess)
                {
                    return new ServiceResultModel<IEnumerable<GameGenre>>
                    {
                        IsSuccess = result.IsSuccess,
                        ValidationErrors = result.ValidationErrors
                    };
                }
            }

            var toAddGenre = updateGameGenre.Except(gameGenreIenum.Data.MapToModel()).ToList();
            foreach(var addGenre in toAddGenre)
            {
                ServiceResultModel<GameGenre> result = await AddAsync(addGenre);
                if(!result.IsSuccess)
                {
                    return new ServiceResultModel<IEnumerable<GameGenre>>
                    {
                        IsSuccess = result.IsSuccess,
                        ValidationErrors = result.ValidationErrors
                    };
                }
            }

            gameGenreIenum.Data = (await GetByGameIdAsync(updateGameGenreModel.GameId)).Data;

            return gameGenreIenum;
        }

        public async Task<ServiceResultModel<GameGenre>> AddAsync(GameGenreModel gameGenreModel)
        {
            ServiceResultModel<GameGenre> result = new();

            try
            {
                await _gameGenreRepository.AddAsync(gameGenreModel.MapToEntity());

                result.Data = gameGenreModel.MapToEntity();
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

        public async Task<ServiceResultModel<GameGenre>> DeleteAsync(GameGenreModel gameGenreModel)
        {
            ServiceResultModel<GameGenre> result = new();

            if(!(await _gameGenreRepository.DoesExistAsync(gg => gg.GenreId == gameGenreModel.GenreId && gg.GameId == gameGenreModel.GameId)))
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult("A many to many relationship does not exist"));
                return result;
            }

            try
            {
                await _gameGenreRepository.DeleteAsync(gameGenreModel.MapToEntity());

                result.Data = gameGenreModel.MapToEntity();
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

