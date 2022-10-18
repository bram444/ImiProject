﻿using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Dto.UserGame;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private UserGame CreateEntity(UserGameResponseDto userGameResponseDto)
        {
            UserGame gameGenre = new UserGame
            {
                GameId = userGameResponseDto.GameId,
                 UserId = userGameResponseDto.UserId,
            };
            return gameGenre;
        }
        public async Task<ServiceResult<UserGame>> AddAsync(UserGameResponseDto entity)
        {
            var serviceResponse = new ServiceResult<UserGame>();
            var userGameEntity = CreateEntity(entity);

            try
            {
                await _userGameRepository.AddAsync(userGameEntity);
                serviceResponse.Result = userGameEntity;
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResult<UserGame>> DeleteAsync(UserGameResponseDto entity)
        {
            var serviceResponse = new ServiceResult<UserGame>();
            var userGameEntity = CreateEntity(entity);

            try
            {
                await _userGameRepository.DeleteAsync(userGameEntity);
                serviceResponse.Result = userGameEntity;
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public IQueryable<UserGame> GetAll()
        {
            return  _userGameRepository.GetAll();
        }

        public async Task<UserGame> GetByGameIdAsync(Guid id)
        {
            return await _userGameRepository.GetByGameIdAsync(id);
        }

        public async Task<UserGame> GetByUserIdAsync(Guid id)
        {
            return await _userGameRepository.GetByUserIdAsync(id);

        }

        public async Task<IEnumerable<UserGame>> ListAllAsync()
        {
            return await _userGameRepository.ListAllAsync();
        }

        public async Task<ServiceResult<UserGame>> UpdateAsync(UserGameResponseDto entity)
        {
            var serviceResponse = new ServiceResult<UserGame>();
            var userGameEntity = CreateEntity(entity);

            try
            {
                await _userGameRepository.UpdateAsync(userGameEntity);
                serviceResponse.Result = userGameEntity;
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }
    }
}
