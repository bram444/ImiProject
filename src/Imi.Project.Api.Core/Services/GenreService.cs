using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.Genre;
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
    public class GenreService :IGenreService
    {
        private readonly IGenreRepository _genreRepository;


        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;

        }
        private Genre CreateEntity(GenreResponseDto  genreResponseDto)
        {
            Genre genre = new Genre
            {
                 Id= genreResponseDto.Id,
                 Name= genreResponseDto.Name,
                 Description= genreResponseDto.Description,
            };
            return genre;
        }

        public async Task<Genre> AddAsync(GenreResponseDto entity)
        {
            return await _genreRepository.AddAsync(CreateEntity(entity));
        }

        public async Task<Genre> DeleteAsync(GenreResponseDto entity)
        {
            return await _genreRepository.DeleteAsync(CreateEntity(entity));
        }

        public IQueryable<Genre> GetAll()
        {
            return _genreRepository.GetAll();
        }

        public async Task<Genre> GetByIdAsync(Guid id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Genre>> ListAllAsync()
        {
            return await _genreRepository.ListAllAsync();
        }

        public async Task<IEnumerable<Genre>> SearchAsync(string search)
        {
            return await _genreRepository.SearchAsync(search);
        }

        public async Task<Genre> UpdateAsync(GenreResponseDto entity)
        {
            return await _genreRepository.UpdateAsync(CreateEntity(entity));
        }
    }
}
