using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapping;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;

        public UserService(IUserRepository userRepository, IGameRepository gameRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }

        public async Task<ServiceResultModel<IEnumerable<ApplicationUser>>> ListAllAsync()
        {
            ServiceResultModel<IEnumerable<ApplicationUser>> result = new();
            try
            {
                result.Data = await _userRepository.ListAllAsync();
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

        public async Task<ServiceResultModel<ApplicationUser>> GetByIdAsync(Guid id)
        {
            ServiceResultModel<ApplicationUser> result = new();
            try
            {
                result.Data = await _userRepository.GetByIdAsync(id);
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

        public async Task<ServiceResultModel<IEnumerable<ApplicationUser>>> SearchUserNameAsync(string search)
        {
            ServiceResultModel<IEnumerable<ApplicationUser>> result = new();
            try
            {
                result.Data = await _userRepository.SearchUserNameAsync(search);
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

        public async Task<ServiceResultModel<IEnumerable<ApplicationUser>>> SearchFirstNameAsync(string search)
        {
            ServiceResultModel<IEnumerable<ApplicationUser>> result = new();
            try
            {
                result.Data = await _userRepository.SearchFirstNameAsync(search);
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

        public async Task<ServiceResultModel<IEnumerable<ApplicationUser>>> SearchLastNameAsync(string search)
        {
            ServiceResultModel<IEnumerable<ApplicationUser>> result = new();
            try
            {
                result.Data = await _userRepository.SearchLastNameAsync(search);
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

        public async Task<ServiceResultModel<ApplicationUser>> AddAsync(NewUserModel response)
        {
            ServiceResultModel<ApplicationUser> result = new();

            try
            {
                if(await _userRepository.DoesExistAsync(user => (user.UserName == response.UserName)))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User with username {response.UserName} already exists"));
                }

                if(await _userRepository.DoesExistAsync(user => (user.Email == response.Email)))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User with email already exists"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                var user = response.MapToEntity();

                await _userRepository.AddAsync(user);

                result.Data = user;
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

        public async Task<ServiceResultModel<ApplicationUser>> UpdateAsync(UpdateUserModel response)
        {
            ServiceResultModel<ApplicationUser> result = new();

            try
            {

                if(!await _userRepository.DoesExistAsync(response.Id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User {response.Id} doesn't exists"));
                }

                IEnumerable<ApplicationUser> allUsers = await _userRepository.SearchUserNameAsync(response.UserName);

                if(await _userRepository.DoesExistAsync(user => (user.UserName == response.UserName) && (user.Id != response.Id)))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User with username {response.UserName} already exists"));
                }


                foreach(var id in response.GameId)
                {
                    if(!await _gameRepository.DoesExistAsync(id))
                    {
                        result.IsSuccess = false;
                        result.ValidationErrors.Add(new ValidationResult($"Game with id {id} doesn't exist"));
                    }
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                ApplicationUser editUser = await _userRepository.GetByIdAsync(response.Id);

                var user = response.MapToEntity(editUser);

                await _userRepository.UpdateAsync(editUser);

                result.Data = editUser;
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

        public async Task<ServiceResultModel<ApplicationUser>> DeleteAsync(Guid id)
        {
            ServiceResultModel<ApplicationUser> result = new();

            try
            {
                if(!await _userRepository.DoesExistAsync(id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("User does not exist"));
                    return result;
                }

                await _userRepository.DeleteAsync(await _userRepository.GetByIdAsync(id));

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