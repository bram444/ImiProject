using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Genre;
using Imi.Project.Api.Dto.Genre;

namespace Imi.Project.Api.Mapper
{
    public static class MapperGenre
    {
        public static NewGenreModel MapToModel(this NewGenreRequestDto newGenre)
        {
            return new NewGenreModel
            {
                Name = newGenre.Name.Trim(' '),
                Description = newGenre.Description?.Trim(' ')
            };
        }

        public static UpdateGenreModel MapToModel(this UpdateGenreRequestDto updateGenre)
        {
            return new UpdateGenreModel
            {
                Id = updateGenre.Id,
                Name = updateGenre.Name.Trim(' '),
                Description = updateGenre.Description?.Trim(' ')
            };
        }

        public static GenreResponseDto MapToDto(this Genre genre)
        {
            return new GenreResponseDto
            {
                Id = genre.Id,
                Name = genre.Name.Trim(' '),
                Description = genre.Description?.Trim(' ')
            };
        }

        public static IEnumerable<GenreResponseDto> MapToDtos(this IEnumerable<Genre> genres)
        {
            return genres.Select(genre => genre.MapToDto());
        }
    }
}