using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Genre;
using System;

namespace Imi.Project.Api.Core.Mapper
{
    public static class GenreEntityMapper
    {
        public static Genre MapToEntity(this NewGenreModel newGenre)
        {
            return new Genre
            {
                Id = Guid.NewGuid(),
                Name = newGenre.Name,
                Description = newGenre.Description
            };
        }

        public static Genre MapToEntity(this UpdateGenreModel updateGenre)
        {
            return new Genre
            {
                Id = updateGenre.Id,
                Name = updateGenre.Name,
                Description = updateGenre.Description
            };
        }
    }
}