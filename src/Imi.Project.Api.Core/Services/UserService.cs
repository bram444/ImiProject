using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

        public UserService(IUserRepository userRepository, IGameRepository gameRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }

        public async Task<ServiceResultModel<ApplicationUser>> AddAsync(UserRequestModel response)
        {
            ServiceResultModel<ApplicationUser> result = new()
            {
                IsSuccess = true
            };

            try
            {
                var allUsers= await _userRepository.SearchUserNameAsync(response.UserName);

                if(allUsers.Any(user => (user.UserName == response.UserName) && (user.Id != response.Id)) && allUsers.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User with username {response.UserName} already exists"));
                }

                allUsers = await _userRepository.SearchEmailAsync(response.Email);

                if(allUsers.Any(user => (user.Email == response.Email) && (user.Id != response.Id)) && allUsers.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User with email already exists"));
                }

                List<Game> allGames = new();

                foreach(var gameId in response.GameId)
                {
                    Game game = await _gameRepository.GetByIdAsync(gameId);

                    if(game == null)
                    {
                        result.IsSuccess = false;
                        result.ValidationErrors.Add(new ValidationResult($"Game with id {gameId} doesn't exist"));
                    } else
                    {
                        allGames.Add(game);
                    }
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                var user = new ApplicationUser
                {
                    Id = response.Id,
                    Email = response.Email,
                    FirstName = response.FirstName,
                    LastName = response.LastName,
                    UserName = response.UserName,
                    ApprovedTerms = response.ApprovedTerms,
                    BirthDay = response.BirthDay,
                    NormalizedEmail = response.Email.Normalize(),
                    NormalizedUserName = response.UserName.Normalize(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = passwordHasher.HashPassword(user, response.Password);

                await _userRepository.AddAsync(user);

                result.IsSuccess = true;
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

        public async Task<ServiceResultModel<ApplicationUser>> DeleteAsync(Guid id)
        {
            ServiceResultModel<ApplicationUser> result = await GetByIdAsync(id);

            if(!result.IsSuccess)
            {
                return result;
            }

            try
            {
                await _userRepository.DeleteAsync(result.Data);

                result.IsSuccess = true;
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
                result.IsSuccess = true;
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

        public async Task<ServiceResultModel<IEnumerable<ApplicationUser>>> ListAllAsync()
        {
            ServiceResultModel<IEnumerable<ApplicationUser>> result = new();
            try
            {
                result.Data = await _userRepository.ListAllAsync();
                result.IsSuccess = true;
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
                result.IsSuccess = true;
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
                result.IsSuccess = true;
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
                result.IsSuccess = true;
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

        public async Task<ServiceResultModel<ApplicationUser>> UpdateAsync(UserRequestModel response)
        {
            ServiceResultModel<ApplicationUser> result = new();

            try
            {
                ApplicationUser editUser = await _userRepository.GetByIdAsync(response.Id);

                if(editUser==null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User {response.Id} doesn't exists"));
                }

                var allUsers = await _userRepository.SearchUserNameAsync(response.UserName);

                if(allUsers.Any(user => (user.UserName == response.UserName) && (user.Id != response.Id)) && allUsers.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User with username {response.UserName} already exists"));
                }

                allUsers = await _userRepository.SearchEmailAsync(response.Email);

                if(allUsers.Any(user => (user.Email == response.Email) && (user.Id != response.Id)) && allUsers.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"User with email already exists"));
                }

                List<Game> allGames = new();

                foreach(var gameId in response.GameId)
                {
                    Game game = await _gameRepository.GetByIdAsync(gameId);

                    if(game == null)
                    {
                        result.IsSuccess = false;
                        result.ValidationErrors.Add(new ValidationResult($"Game with id {gameId} doesn't exist"));
                    } else
                    {
                        allGames.Add(game);
                    }
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                editUser.Email = response.Email;
                editUser.FirstName = response.FirstName;
                editUser.LastName = response.LastName;
                editUser.UserName = response.UserName;
                editUser.PasswordHash = passwordHasher.HashPassword(editUser, response.Password);
                editUser.BirthDay = response.BirthDay;
                editUser.NormalizedEmail = response.Email.Normalize();
                editUser.NormalizedUserName = response.UserName.Normalize();

                await _userRepository.UpdateAsync(editUser);

                result.IsSuccess = true;
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
    }
}