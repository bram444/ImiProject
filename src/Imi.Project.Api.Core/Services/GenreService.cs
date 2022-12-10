using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GenreService: IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        private static Genre CreateEntity(GenreResponseDto genreResponseDto)
        {
            Genre genre = new()
            {
                Id = genreResponseDto.Id,
                Name = genreResponseDto.Name,
                Description = genreResponseDto.Description,
            };

            return genre;
        }

        private static GenreResponseDto CreateDto(Genre genre)
        {
            GenreResponseDto genreDto = new()
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
            };

            return genreDto;
        }

        public async Task<ServiceResult<GenreResponseDto>> AddAsync(GenreResponseDto response)
        {
            ServiceResult<GenreResponseDto> serviceResponse = new();

            try
            {
                serviceResponse.Result = CreateDto(await _genreRepository.AddAsync(CreateEntity(response)));
            } catch(Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResult<GenreResponseDto>> DeleteAsync(Guid id)
        {
            ServiceResult<GenreResponseDto> serviceResponse = new();

            if(await _genreRepository.GetByIdAsync(id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Genre does not exist");
                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _genreRepository.DeleteAsync(await _genreRepository.GetByIdAsync(id)));
            } catch(Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }

            return serviceResponse;
        }

        public IQueryable<GenreResponseDto> GetAll()
        {
            List<GenreResponseDto> genreResponseDtos = new();
            foreach(Genre entity in _genreRepository.GetAll())
            {
                genreResponseDtos.Add(CreateDto(entity));
            }

            return genreResponseDtos.AsQueryable();
        }

        public async Task<GenreResponseDto> GetByIdAsync(Guid id)
        {
            return CreateDto(await _genreRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<GenreResponseDto>> ListAllAsync()
        {
            List<GenreResponseDto> genreResponseDtos = new();
            foreach(Genre entity in await _genreRepository.ListAllAsync())
            {
                genreResponseDtos.Add(CreateDto(entity));
            }

            return genreResponseDtos;
        }

        public async Task<IEnumerable<GenreResponseDto>> SearchAsync(string search)
        {
            List<GenreResponseDto> genreResponseDtos = new();
            foreach(Genre entity in await _genreRepository.SearchAsync(search))
            {
                genreResponseDtos.Add(CreateDto(entity));
            }

            return genreResponseDtos;
        }

        public async Task<ServiceResult<GenreResponseDto>> UpdateAsync(GenreResponseDto response)
        {
            ServiceResult<GenreResponseDto> serviceResponse = new();

            if(await _genreRepository.GetByIdAsync(response.Id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Genre does not exist");
                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _genreRepository.UpdateAsync(CreateEntity(response)));
            } catch(Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }
    }
}