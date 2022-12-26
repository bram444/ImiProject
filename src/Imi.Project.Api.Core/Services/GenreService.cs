using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<ServiceResultModel<Genre>> AddAsync(GenreModel entity)
        {
            ServiceResultModel<Genre> result = new();

            try
            {
                var allgenres = await _genreRepository.SearchAsync(entity.Name);

                if(allgenres.Any(genre => (genre.Name == entity.Name) && (genre.Id != entity.Id)) && allgenres.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Genre with name {entity.Name} already exists"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                Genre genre = new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description
                };

                await _genreRepository.AddAsync(genre);

                result.IsSuccess = true;
                result.Data = genre;
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

        public async Task<ServiceResultModel<Genre>> DeleteAsync(Guid id)
        {
            ServiceResultModel<Genre> result = new();

            if (await _genreRepository.GetByIdAsync(id) == null)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult("Genre does not exist"));
                return result;
            }

            try
            {

                await _genreRepository.DeleteAsync(await _genreRepository.GetByIdAsync(id));
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

        public async Task<ServiceResultModel<Genre>> GetByIdAsync(Guid id)
        {
            ServiceResultModel<Genre> result = new();
            try
            {
                Genre genre = await _genreRepository.GetByIdAsync(id);
                if(genre == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Genre soes not exist"));
                    return result;
                }

                result.IsSuccess = true;
                result.Data = genre;
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

        public async Task<ServiceResultModel<IEnumerable<Genre>>> ListAllAsync()
        {
            ServiceResultModel<IEnumerable<Genre>> result = new();
            try
            {
                result.Data = await _genreRepository.ListAllAsync();
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

        public async Task<ServiceResultModel<IEnumerable<Genre>>> SearchAsync(string search)
        {
            ServiceResultModel<IEnumerable<Genre>> result = new();
            try
            {
                result.Data = await _genreRepository.SearchAsync(search);
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

        public async Task<ServiceResultModel<Genre>> UpdateAsync(GenreModel entity)
        {
            ServiceResultModel<Genre> result = new()
            {
                IsSuccess = true,
            };

            try
            {
                if(await _genreRepository.GetByIdAsync(entity.Id) == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Genre does not exist"));
                }

                var allgenres = await _genreRepository.SearchAsync(entity.Name);

                if(allgenres.Any(genre => (genre.Name == entity.Name) && (genre.Id != entity.Id))&& allgenres.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Genre with name {entity.Name} already exists"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                await _genreRepository.UpdateAsync(new Genre
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description
                });

                result.IsSuccess = true;
                result.Data = new Genre
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description
                };
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
    }
}