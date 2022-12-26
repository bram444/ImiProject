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
    public class GameGenreService : IGameGenreService
    {
        private readonly IGameGenreRepository _gameGenreRepository;

        public GameGenreService(IGameGenreRepository gameGenreRepository)
        {
            _gameGenreRepository = gameGenreRepository;
        }

        public async Task<ServiceResultModel<GameGenre>> AddAsync(GameGenreModel gameGenreModel)
        {
            ServiceResultModel<GameGenre> result = new();

            try
            {
                await _gameGenreRepository.AddAsync(new GameGenre { GameId = gameGenreModel.GameId, GenreId = gameGenreModel.GenreId });

                result.Data = new GameGenre { GameId = gameGenreModel.GameId, GenreId = gameGenreModel.GenreId };
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

        public async Task<ServiceResultModel<GameGenre>> DeleteAsync(GameGenreModel gameGenreModel)
        {
            ServiceResultModel<GameGenre> result = new();

            if (!_gameGenreRepository.ListAllAsync().Result.Any(gg => gg.GenreId == gameGenreModel.GenreId && gg.GameId == gameGenreModel.GameId))
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult("A many to many relationship does not exist"));
                return result;
            }

            try
            {
                await _gameGenreRepository.DeleteAsync(new GameGenre { GameId = gameGenreModel.GameId, GenreId = gameGenreModel.GenreId });

                result.Data = new GameGenre { GameId = gameGenreModel.GameId, GenreId = gameGenreModel.GenreId };
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

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> GetByGameIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<GameGenre>> result = new();

            List<GameGenre> gameGenres = new();

            try
            {

                foreach (GameGenre entity in await _gameGenreRepository.GetByGameIdAsync(id))
                {
                    gameGenres.Add(entity);
                }

                result.Data = gameGenres;
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

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> GetByGenreIdAsync(Guid id)
        {
            ServiceResultModel<IEnumerable<GameGenre>> result = new();

            List<GameGenre> gameGenres = new();

            try
            {

                foreach (GameGenre entity in await _gameGenreRepository.GetByGenreIdAsync(id))
                {
                    gameGenres.Add(entity);
                }

                result.Data = gameGenres;
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

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> ListAllAsync()
        {
            ServiceResultModel<IEnumerable<GameGenre>> result = new();

            List<GameGenre> gameGenres = new();

            try
            {
                foreach (GameGenre entity in await _gameGenreRepository.ListAllAsync())
                {
                    gameGenres.Add(entity);
                }

                result.Data = gameGenres;
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

        public async Task<ServiceResultModel<IEnumerable<GameGenre>>> EditGameGenreAsync(GameModel gameResponseDto)
        {
            ServiceResultModel<IEnumerable<GameGenre>> gameGenreIenum = await GetByGameIdAsync(gameResponseDto.Id);

            if (!gameGenreIenum.IsSuccess)
            {
                return gameGenreIenum;
            }

            List<GameGenre> updateGameGenre = new();

            foreach (Guid genreId in gameResponseDto.GenreId.Distinct())
            {
                updateGameGenre.Add(new GameGenre
                {
                    GenreId = genreId,
                    GameId = gameResponseDto.Id
                });
            }

            List<GameGenre> toDeleteGenre = gameGenreIenum.Data.Except(updateGameGenre).ToList();
            foreach (GameGenre deleteGenre in toDeleteGenre)
            {
                ServiceResultModel<GameGenre> result = await DeleteAsync(new GameGenreModel { GameId = deleteGenre.GameId, GenreId = deleteGenre.GenreId });
                if (!result.IsSuccess)
                {
                    return new ServiceResultModel<IEnumerable<GameGenre>>
                    {
                        IsSuccess = result.IsSuccess,
                        ValidationErrors = result.ValidationErrors
                    };
                }
            }

            List<GameGenre> toAddGenre = updateGameGenre.Except(gameGenreIenum.Data).ToList();
            foreach (GameGenre addGenre in toAddGenre)
            {
                ServiceResultModel<GameGenre> result = await AddAsync(new GameGenreModel { GameId = addGenre.GameId, GenreId = addGenre.GenreId });
                if (!result.IsSuccess)
                {
                    return new ServiceResultModel<IEnumerable<GameGenre>>
                    {
                        IsSuccess = result.IsSuccess,
                        ValidationErrors = result.ValidationErrors
                    };
                }
            }

            return new ServiceResultModel<IEnumerable<GameGenre>> { Data = updateGameGenre, IsSuccess = true };
        }
    }
}