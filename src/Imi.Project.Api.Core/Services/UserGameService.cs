using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapping;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.UserGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserGameService: IUserGameService
    {

        private readonly IUserGameRepository _userGameRepository;

        public UserGameService(IUserGameRepository userGameRepository)
        {
            _userGameRepository = userGameRepository;
        }

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> ListAllAsync()
        {
            ServiceResultModel<IEnumerable<UserGame>> result = new();

            try
            {
                result.Data = await _userGameRepository.ListAllAsync();
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

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> GetByUserIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<UserGame>> result = new();

            try
            {
                result.Data = await _userGameRepository.GetByUserIdAsync(id);
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

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> GetByGameIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<UserGame>> result = new();

            try
            {
                result.Data = await _userGameRepository.GetByGameIdAsync(id);
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

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> EditUserGameAsync(UpdateUserGameModel model)
        {
            ServiceResultModel<IEnumerable<UserGame>> result = await GetByUserIdAsync(model.UserId);

            if(!result.IsSuccess)
            {
                return result;
            }

            List<UserGameModel> updateUserGame = new();

            foreach(Guid gameId in model.GameIds.Distinct())
            {
                updateUserGame.Add(UserGameEntityMapper.UserGameModelMapper(model.UserId, gameId));
            }

            var toDelete = result.Data.MapToModel().Except(updateUserGame).ToList();

            foreach(var delete in toDelete)
            {
                ServiceResultModel<UserGame> resultY = await DeleteAsync(delete);
                if(!resultY.IsSuccess)
                {
                    return new ServiceResultModel<IEnumerable<UserGame>>
                    {
                        IsSuccess = resultY.IsSuccess,
                        ValidationErrors = resultY.ValidationErrors
                    };
                }
            }

            var toAdd= updateUserGame.Except(result.Data.MapToModel()).ToList();
            foreach(var add in toAdd)
            {
                ServiceResultModel<UserGame> resultYY = await AddAsync(add);
                if(!resultYY.IsSuccess)
                {
                    return new ServiceResultModel<IEnumerable<UserGame>>
                    {
                        IsSuccess = resultYY.IsSuccess,
                        ValidationErrors = resultYY.ValidationErrors
                    };
                }
            }

            result.Data = (await GetByUserIdAsync(model.UserId)).Data;

            return result;
        }

        public async Task<ServiceResultModel<UserGame>> AddAsync(UserGameModel model)
        {
            ServiceResultModel<UserGame> result = new();

            try
            {
                await _userGameRepository.AddAsync(new UserGame
                {
                    UserId = model.UserId,
                    GameId = model.GameId,
                });

                result.Data = new UserGame
                {
                    UserId = model.UserId,
                    GameId = model.GameId,
                };

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

        public async Task<ServiceResultModel<UserGame>> DeleteAsync(UserGameModel model)
        {
            ServiceResultModel<UserGame> result = new();

            try
            {
                if(!(await _userGameRepository.ListAllAsync()).Any(gg => gg.UserId == model.UserId && gg.GameId == model.GameId))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Many to many relationship does not exist"));
                    return result;
                }

                await _userGameRepository.DeleteAsync(new UserGame
                {
                    UserId = model.UserId,
                    GameId = model.GameId,
                });

                result.Data = new UserGame
                {
                    UserId = model.UserId,
                    GameId = model.GameId,
                };

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