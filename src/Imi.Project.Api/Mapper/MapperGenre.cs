using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Game;
using Imi.Project.Api.Core.Models.Genre;
using Imi.Project.Api.Dto.Game;
using Imi.Project.Api.Dto.Genre;

namespace Imi.Project.Api.Mapper
{
    public static class MapperGenre
    {
        public static NewGenreModel NewGenreModelMapper(this NewGenreRequestDto newGenre)
        {
            return new NewGenreModel
            {
                Name = newGenre.Name,
                 Description = newGenre.Description,
            };
        }

        public static UpdateGenreModel UpdateGameModelMapper(this UpdateGenreRequestDto updateGenre)
        {
            return new UpdateGenreModel
            {
                Id = updateGenre.Id,
                Name = updateGenre.Name,
                Description = updateGenre.Description,
            };
        }

        public static GenreResponseDto GenreResponseDtoMapper(this Genre genre)
        {
            return new GenreResponseDto
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description
            };
        }

        public static IEnumerable<GenreResponseDto> GenreResponseDtoMapper(this IEnumerable<Genre> genres)
        {
            return genres.Select(genre=>genre.GenreResponseDtoMapper());
        }
    }
}
