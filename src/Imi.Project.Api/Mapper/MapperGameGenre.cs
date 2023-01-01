using Imi.Project.Api.Core.Models.GameGenre;
using Imi.Project.Api.Dto.Game;

namespace Imi.Project.Api.Mapper
{
    public static class MapperGameGenre
    {
        public static UpdateGameGenreModel MapToUpdateModel(this NewGameRequestDto game, Guid gameId)
        {
            return new UpdateGameGenreModel
            {
                GenreIds = game.GenreId,
                GameId = gameId
            };
        }

        public static UpdateGameGenreModel MapToGameGenreModel(this UpdateGameRequestDto gameModel)
        {
            return new UpdateGameGenreModel
            {
                GenreIds = gameModel.GenreId.Distinct(),
                GameId = gameModel.Id
            };
        }
    }
}