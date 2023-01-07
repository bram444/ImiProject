using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapper;
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
            try
            {
                return new ServiceResultModel<IEnumerable<ApplicationUser>>
                {
                    Data = await _userRepository.ListAllAsync()
                };
            } catch(Exception ex)
            {
                return SetErrorUserList(ex);
            }
        }

        public async Task<ServiceResultModel<ApplicationUser>> GetByIdAsync(Guid id)
        {
            try
            {
                return new ServiceResultModel<ApplicationUser>
                {
                    Data = await _userRepository.GetByIdAsync(id)
                };
            } catch(Exception ex)
            {
                return SetErrorUser(ex);
            }
        }

        public async Task<ServiceResultModel<IEnumerable<ApplicationUser>>> SearchUserNameAsync(string search)
        {
            try
            {
                return new ServiceResultModel<IEnumerable<ApplicationUser>>
                {
                    Data = await _userRepository.SearchUserNameAsync(search)
                };
            } catch(Exception ex)
            {
                return SetErrorUserList(ex);
            }
        }

        public async Task<ServiceResultModel<IEnumerable<ApplicationUser>>> SearchFirstNameAsync(string search)
        {
            try
            {
                return new ServiceResultModel<IEnumerable<ApplicationUser>>
                {
                    Data = await _userRepository.SearchFirstNameAsync(search)
                };
            } catch(Exception ex)
            {
                return SetErrorUserList(ex);
            }
        }

        public async Task<ServiceResultModel<IEnumerable<ApplicationUser>>> SearchLastNameAsync(string search)
        {
            try
            {
                return new ServiceResultModel<IEnumerable<ApplicationUser>>
                {
                    Data = await _userRepository.SearchLastNameAsync(search)
                };
            } catch(Exception ex)
            {
                return SetErrorUserList(ex);
            }
        }

        public async Task<ServiceResultModel<ApplicationUser>> AddAsync(NewUserModel response)
        {
            try
            {
                ApplicationUser userEntity = response.MapToEntity();

                ServiceResultModel<ApplicationUser> result = new();

                if(await _userRepository.DoesExistAsync(user => user.UserName == userEntity.UserName))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Username {userEntity.UserName} already exists"));
                }

                if(await _userRepository.DoesExistAsync(user => user.Email == userEntity.Email))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User with email already exists"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                await _userRepository.AddAsync(userEntity);

                return new ServiceResultModel<ApplicationUser>
                {
                    Data = userEntity
                };

            } catch(Exception ex)
            {
                return SetErrorUser(ex);
            }
        }

        public async Task<ServiceResultModel<ApplicationUser>> UpdateAsync(UpdateUserModel response)
        {
            try
            {
                ServiceResultModel<ApplicationUser> result = new();

                if(!await _userRepository.DoesExistAsync(response.Id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User {response.Id} doesn't exists"));
                }

                if(await _userRepository.DoesExistAsync(user => (user.UserName == response.UserName) && (user.Id != response.Id)))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Username {response.UserName} already exists"));
                }

                foreach(Guid id in response.GameId)
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

                ApplicationUser editUser = response.MapToEntity(await _userRepository.GetByIdAsync(response.Id));

                await _userRepository.UpdateAsync(editUser);

                return new ServiceResultModel<ApplicationUser>
                {
                    Data = editUser
                };

            } catch(Exception ex)
            {
                return SetErrorUser(ex);
            }
        }

        public async Task<ServiceResultModel<ApplicationUser>> DeleteAsync(Guid id)
        {
            try
            {
                if(await _userRepository.DoesExistAsync(id))
                {
                    await _userRepository.DeleteAsync(await _userRepository.GetByIdAsync(id));

                    return new ServiceResultModel<ApplicationUser> { };
                }
                return new ServiceResultModel<ApplicationUser>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("User does not exist") }
                };

            } catch(Exception ex)
            {
                return SetErrorUser(ex);
            }
        }

        private static ServiceResultModel<IEnumerable<ApplicationUser>> SetErrorUserList(Exception ex)
        {
            return new ServiceResultModel<IEnumerable<ApplicationUser>>
            {
                IsSuccess = false,
                ValidationErrors = GetResult(ex)
            };
        }

        private static ServiceResultModel<ApplicationUser> SetErrorUser(Exception ex)
        {
            return new ServiceResultModel<ApplicationUser>
            {
                IsSuccess = false,
                ValidationErrors = GetResult(ex)
            };
        }

        private static IList<ValidationResult> GetResult(Exception ex)
        {
            List<ValidationResult> error = new()
            {
                new ValidationResult(ex.Message)
            };

            if(ex.InnerException != null)
            {
                error.Add(new ValidationResult(ex.InnerException.Message));
            }

            return error;
        }
    }
}