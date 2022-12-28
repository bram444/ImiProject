using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.GameGenre;
using Imi.Project.Api.Dto.Game;

namespace Imi.Project.Api.Mapper
{
    public static class MapperGameGenre
    {
        public static GameGenreModel GameGenreModelMapper(Guid genreId, Guid gameId)
        {
            return new GameGenreModel
            {
                GenreId = genreId,
                GameId = gameId
            };
        }

        public static UpdateGameGenreModel UpdateGameGenreModelMapper(this UpdateGameRequestDto gameModel)
        {
            return new UpdateGameGenreModel
            {
                GenreIds = gameModel.GenreId.Distinct(),
                GameId = gameModel.Id
            };
        }
    }
}
