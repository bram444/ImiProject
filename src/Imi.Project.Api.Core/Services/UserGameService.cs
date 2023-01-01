using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapper;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.UserGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserGameService: BaseGameMTMService<IUserGameRepository, UserGame, UserGameModel>, IUserGameService
    {
        public UserGameService(IUserGameRepository userGameRepository):base(userGameRepository)
        {
        }

        //public async Task<ServiceResultModel<IEnumerable<UserGame>>> ListAllAsync()
        //{
        //    ServiceResultModel<IEnumerable<UserGame>> result = new();

        //    try
        //    {
        //        result.Data = await _userGameRepository.ListAllAsync();
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

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> GetByUserIdAsync(Guid id)
        {
            try
            {
                return new ServiceResultModel<IEnumerable<UserGame>>()
                {
                    Data = await _irespository.GetByUserIdAsync(id)
                };
            } catch(Exception ex)
            {
                return SetErrorList(ex);
            }
        }

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> EditUserGameAsync(UpdateUserGameModel model)
        {
            try
            {
                var resultUserGame = await GetByUserIdAsync(model.UserId);

                if(!resultUserGame.IsSuccess)
                {
                    return resultUserGame;
                }

                List<UserGameModel> updateUserGame = model.GameIds.Select(gameId =>
                UserGameEntityMapper.MapToModel(model.UserId, gameId)).ToList();

                var oldUserGame = resultUserGame.Data.MapToModel();

                var toDelete = oldUserGame.Except(updateUserGame).ToList();

                foreach(var delete in toDelete)
                {
                    ServiceResultModel<UserGame> resultDelete = await DeleteAsync(delete);
                    if(!resultDelete.IsSuccess)
                    {
                        return new ServiceResultModel<IEnumerable<UserGame>>
                        {
                            IsSuccess = resultDelete.IsSuccess,
                            ValidationErrors = resultDelete.ValidationErrors
                        };
                    }
                }

                var toAdd = updateUserGame.Except(oldUserGame).ToList();

                foreach(var add in toAdd)
                {
                    ServiceResultModel<UserGame> resultAdd = await AddAsync(add);
                    if(!resultAdd.IsSuccess)
                    {
                        return new ServiceResultModel<IEnumerable<UserGame>>
                        {
                            IsSuccess = resultAdd.IsSuccess,
                            ValidationErrors = resultAdd.ValidationErrors
                        };
                    }
                }

                return new ServiceResultModel<IEnumerable<UserGame>>
                {
                    Data = (await GetByUserIdAsync(model.UserId)).Data
                };
            }catch(Exception ex)
            {
                return SetErrorList(ex);
            }
        }

        public override async Task<ServiceResultModel<UserGame>> AddAsync(UserGameModel TModel)
        {
            try
            {
                var userGame = TModel.MapToEntity();
                
                await _irespository.AddAsync(userGame);

                return  new ServiceResultModel<UserGame>
                {
                     Data= userGame
                };
            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }

        public override async Task<ServiceResultModel<UserGame>> DeleteAsync(UserGameModel TModel)
        {
            try
            {
                if(!await _irespository.DoesExistAsync(gg => gg.GameId == TModel.GameId && gg.UserId == TModel.UserId))
                {
                    return new ServiceResultModel<UserGame>
                    {
                        IsSuccess = false,
                        ValidationErrors = new List<ValidationResult> { new ValidationResult($"A many to many relationship {nameof(UserGame)} does not exist") }
                    };
                }

                var userGame = TModel.MapToEntity();

                await _irespository.DeleteAsync(userGame);

                return new ServiceResultModel<UserGame>
                {
                    Data = userGame
                };

            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }
    }
}