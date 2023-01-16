using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapper;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.Genre;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GenreService: BaseService<Genre, IGenreRepository, NewGenreModel, UpdateGenreModel>, IGenreService
    {
        public GenreService(IGenreRepository genreRepository) : base(genreRepository)
        {
        }

        public override async Task<ServiceResultModel<Genre>> AddAsync(NewGenreModel entity)
        {
            try
            {
                if(await _itemRepository.DoesExistAsync(genre => genre.Name == entity.Name))
                {
                    return new ServiceResultModel<Genre>
                    {
                        IsSuccess = false,
                        ValidationErrors = new List<string>
                        {
                           $"Genre with name {entity.Name} already exists"
                        }
                    };
                }

                Genre genre = entity.MapToEntity();

                await _itemRepository.AddAsync(genre);

                return new ServiceResultModel<Genre>
                {
                    Data = genre
                };
            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }

        public override async Task<ServiceResultModel<Genre>> UpdateAsync(UpdateGenreModel entity)
        {
            try
            {
                ServiceResultModel<Genre> result = new();

                if(!await _itemRepository.DoesExistAsync(entity.Id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add("Genre does not exist");
                }

                if(await _itemRepository.DoesExistAsync(genre => genre.Name == entity.Name && (genre.Id != entity.Id)))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add($"Genre with name {entity.Name} already exists");
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                Genre genre = entity.MapToEntity();

                await _itemRepository.UpdateAsync(genre);

                return new ServiceResultModel<Genre>
                {
                    Data = genre
                };

            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }
    }
}