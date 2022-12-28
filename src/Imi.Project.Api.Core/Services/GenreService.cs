using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapping;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.Genre;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GenreService:BaseService<Genre,IGenreRepository>, IGenreService
    {
        public GenreService(IGenreRepository genreRepository):base(genreRepository)
        {
        }

        public async Task<ServiceResultModel<Genre>> AddAsync(NewGenreModel entity)
        {
            ServiceResultModel<Genre> result = new();

            try
            {
                if(await _itemRepository.DoesExistAsync(genre => genre.Name == entity.Name))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Genre with name {entity.Name} already exists"));
                    return result;
                }

                Genre genre = entity.MapToEntity();

                await _itemRepository.AddAsync(genre);

                result.Data = genre;
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

        public async Task<ServiceResultModel<Genre>> UpdateAsync(UpdateGenreModel entity)
        {
            ServiceResultModel<Genre> result = new();

            try
            {
                if(!await _itemRepository.DoesExistAsync(entity.Id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Genre does not exist"));
                }

                if(await _itemRepository.DoesExistAsync(genre => genre.Name == entity.Name && (genre.Id != entity.Id)))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Genre with name {entity.Name} already exists"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                Genre genre = entity.MapToEntity();

                await _itemRepository.UpdateAsync(genre);

                result.Data = genre;
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