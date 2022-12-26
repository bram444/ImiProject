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
    public class UserGameService : IUserGameService
    {

        private readonly IUserGameRepository _userGameRepository;

        public UserGameService(IUserGameRepository userGameRepository)
        {
            _userGameRepository = userGameRepository;
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

        public async Task<ServiceResultModel<UserGame>> DeleteAsync(UserGameModel model)
        {
            ServiceResultModel<UserGame> result = new();

            if (!_userGameRepository.ListAllAsync().Result.Any(gg => gg.UserId == model.UserId && gg.GameId == model.GameId))
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult("Many to many relationship does not exist"));
                return result;
            }

            try
            {
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

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> GetByGameIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<UserGame>> result = new();

            try
            {
                result.Data = await _userGameRepository.GetByGameIdAsync(id);
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

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> GetByUserIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<UserGame>> result = new();

            try
            {
                result.Data = await _userGameRepository.GetByUserIdAsync(id);
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

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> ListAllAsync()
        {
            ServiceResultModel<IEnumerable<UserGame>> result = new();

            try
            {
                result.Data = await _userGameRepository.ListAllAsync();
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

        public async Task<ServiceResultModel<IEnumerable<UserGame>>> EditUserGameAsync(UserRequestModel model)
        {

            ServiceResultModel<IEnumerable<UserGame>> result = await GetByUserIdAsync(model.Id);

            List<UserGame> updateUserGame = new();


            foreach (Guid gameId in model.GameId.Distinct())
            {
                updateUserGame.Add(new UserGame
                {
                    GameId = gameId,
                    UserId = model.Id
                });
            }

            List<UserGame> toDeleteGame = result.Data.Except(updateUserGame).ToList();
            foreach (UserGame deleteGame in toDeleteGame)
            {
                ServiceResultModel<UserGame> serviceDelete = await DeleteAsync(new UserGameModel
                {
                    GameId = deleteGame.GameId,
                    UserId = deleteGame.UserId
                });
                if (!serviceDelete.IsSuccess)
                {
                    return new ServiceResultModel<IEnumerable<UserGame>>
                    {
                        IsSuccess = serviceDelete.IsSuccess,
                        ValidationErrors = serviceDelete.ValidationErrors
                    };
                }
            }

            List<UserGame> toAddGame = updateUserGame.Except(result.Data).ToList();
            List<UserGame> listUserGame = new();

            foreach (UserGame addGame in toAddGame)
            {
                ServiceResultModel<UserGame> serviceAdd = await AddAsync(new UserGameModel
                {
                    GameId = addGame.GameId,
                    UserId = addGame.UserId
                });
                if (!serviceAdd.IsSuccess)
                {
                    return new ServiceResultModel<IEnumerable<UserGame>>
                    {
                        IsSuccess = serviceAdd.IsSuccess,
                        ValidationErrors = serviceAdd.ValidationErrors
                    };
                }
                listUserGame.Add(serviceAdd.Data);
            }

            result.Data = listUserGame;
            result.IsSuccess = true;


            return result;
        }
    }
}