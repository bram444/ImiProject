using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.GameGenre;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imi.Project.Api.Core.Mapper
{
    public static class GameGenreEntityMapper
    {
        public static GameGenre MapToEntity(this GameGenreModel gameGenreModel)
        {
            return new GameGenre
            {
                GameId = gameGenreModel.GameId,
                GenreId = gameGenreModel.GenreId,
            };
        }

        public static GameGenreModel MapToModel(this GameGenre gameGenre)
        {
            return new GameGenreModel
            {
                GameId = gameGenre.GameId,
                GenreId = gameGenre.GenreId,
            };
        }

        public static GameGenreModel MapToModel(Guid genreId, Guid gameId)
        {
            return new GameGenreModel
            {
                GenreId = genreId,
                GameId = gameId
            };
        }

        public static IEnumerable<GameGenreModel> MapToModel(this IEnumerable<GameGenre> gameGenres)
        {
            return gameGenres.Select(gg => gg.MapToModel());
        }

        public static IEnumerable<GameGenre> MapToEntity(this IEnumerable<GameGenreModel> gameGenresModel)
        {
            return gameGenresModel.Select(gg => gg.MapToEntity());
        }
    }
}
