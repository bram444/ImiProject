using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Dto.User;
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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;


        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;

        }
        private Genre CreateEntity(GenreResponseDto genreResponseDto)
        {
            Genre genre = new Genre
            {
                Id = genreResponseDto.Id,
                Name = genreResponseDto.Name,
                Description = genreResponseDto.Description,
            };
            return genre;
        }

        private GenreResponseDto CreateDto(Genre genre)
        {
            GenreResponseDto genreDto = new GenreResponseDto
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
            };
            return genreDto;
        }

        public async Task<ServiceResult<GenreResponseDto>> AddAsync(GenreResponseDto response)
        {
            var serviceResponse = new ServiceResult<GenreResponseDto>();

            try
            {
                serviceResponse.Result = CreateDto(await _genreRepository.AddAsync(CreateEntity(response)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;

        }

        public async Task<ServiceResult<GenreResponseDto>> DeleteAsync(Guid id)
        {
            var serviceResponse = new ServiceResult<GenreResponseDto>();

            if (await _genreRepository.GetByIdAsync(id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Genre does not exist");
                return serviceResponse;
            }

            try
            {
                

                serviceResponse.Result = CreateDto(await _genreRepository.DeleteAsync(await _genreRepository.GetByIdAsync(id)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public IQueryable<GenreResponseDto> GetAll()
        {
            List<GenreResponseDto> genreResponseDtos = new List<GenreResponseDto>();
            foreach (Genre entity in _genreRepository.GetAll())
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
            List<GenreResponseDto> genreResponseDtos = new List<GenreResponseDto>();
            foreach (Genre entity in await _genreRepository.ListAllAsync())
            {
                genreResponseDtos.Add(CreateDto(entity));
            }

            return genreResponseDtos;
        }

        public async Task<IEnumerable<GenreResponseDto>> SearchAsync(string search)
        {
            List<GenreResponseDto> genreResponseDtos = new List<GenreResponseDto>();
            foreach (Genre entity in await _genreRepository.SearchAsync(search))
            {
                genreResponseDtos.Add(CreateDto(entity));
            }

            return genreResponseDtos;
        }

        public async Task<ServiceResult<GenreResponseDto>> UpdateAsync(GenreResponseDto response)
        {
            var serviceResponse = new ServiceResult<GenreResponseDto>();

            if (await _genreRepository.GetByIdAsync(response.Id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Genre does not exist");
                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _genreRepository.UpdateAsync(CreateEntity(response)));
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
