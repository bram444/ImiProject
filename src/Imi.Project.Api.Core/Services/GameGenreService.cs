using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapper;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.GameGenre;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GameGenreService: BaseGameMTMService<IGameGenreRepository, GameGenre, GameGenreModel>,
        IGameGenreService
    {
        public GameGenreService(IGameGenreRepository gameGenreRepository) : base(gameGenreRepository)
        {
        }

        //public async Task<ServiceResultModel<IEnumerable<GameGenre>>> ListAllAsync()
        //{
        //    ServiceResultModel<IEnumerable<GameGenre>> result = new();

        //    try
        //    {
        //        result.Data = await _gameGenreRepository.ListAllAsync();
        //        return result;

        //    } catch(Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.ValidationErrors.Add(new ValidationResult(ex.Message));
        //        if(ex.InnerException != null)
        //        {
        //            result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
        //        }
        //        return result;
        //    }
        //}

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> GetByGenreIdAsync(Guid id)
        {
            try
            {
                return new ServiceResultModel<IEnumerable<GameGenre>>
                {
                    Data = await _irespository.GetByGenreIdAsync(id)
                };
            } catch(Exception ex)
            {
                return SetErrorList(ex);
            }
        }

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> EditGameGenreAsync(UpdateGameGenreModel updateGameGenreModel)
        {
            try
            {
                var gameGenreIenum = await GetByGameIdAsync(updateGameGenreModel.GameId);

                if(!gameGenreIenum.IsSuccess)
                {
                    return gameGenreIenum;
                }

                var updateGameGenre = updateGameGenreModel.GenreIds.Select(genreId =>
                GameGenreEntityMapper.MapToModel(genreId, updateGameGenreModel.GameId)).ToList();

                var toDeleteGenre = gameGenreIenum.Data.MapToModel().Except(updateGameGenre).ToList();

                foreach(var deleteGenre in toDeleteGenre)
                {
                    var result = await DeleteAsync(deleteGenre);
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
                    var result = await AddAsync(addGenre);
                    if(!result.IsSuccess)
                    {
                        return new ServiceResultModel<IEnumerable<GameGenre>>
                        {
                            IsSuccess = result.IsSuccess,
                            ValidationErrors = result.ValidationErrors
                        };
                    }
                }

                return new ServiceResultModel<IEnumerable<GameGenre>>
                {
                    Data = (await GetByGameIdAsync(updateGameGenreModel.GameId)).Data
                };
            }catch (Exception ex)
            {
                return SetErrorList(ex);
            }
        }

        public override async Task<ServiceResultModel<GameGenre>> AddAsync(GameGenreModel TModel)
        {
            try
            {
                var gameGenre = TModel.MapToEntity();

                await _irespository.AddAsync(gameGenre);

                return new ServiceResultModel<GameGenre>
                {
                    Data = gameGenre
                };

            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }

        public override async Task<ServiceResultModel<GameGenre>> DeleteAsync(GameGenreModel TModel)
        {
            try
            {
                var gameGenre = TModel.MapToEntity();

                if(!await _irespository.DoesExistAsync(gg => gg.GameId == gameGenre.GameId && gg.GenreId == gameGenre.GenreId))
                {
                    return new ServiceResultModel<GameGenre>
                    {
                        IsSuccess = false,
                        ValidationErrors = new List<ValidationResult> { new ValidationResult($"A many to many relationship {nameof(GameGenre)} does not exist") }
                    };
                }

                await _irespository.DeleteAsync(gameGenre);

                return new ServiceResultModel<GameGenre>
                {
                    Data = gameGenre
                };

            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }
    }
}