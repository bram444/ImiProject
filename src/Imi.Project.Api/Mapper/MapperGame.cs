using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Game;
using Imi.Project.Api.Dto.Game;
using Imi.Project.Api.Dto.Genre;
using Imi.Project.Api.Dto.Publisher;

namespace Imi.Project.Api.Mapper
{
    public static class MapperGame
    {
        public static NewGameModel MapToModel(this NewGameRequestDto newGame)
        {
            return new NewGameModel
            {
                Name = newGame.Name.Trim(' '),
                Price = newGame.Price,
                PublisherId = newGame.PublisherId,
                GenreId = newGame.GenreId.Distinct(),
            };
        }

        public static UpdateGameModel MapToModel(this UpdateGameRequestDto updateGame)
        {
            return new UpdateGameModel
            {
                Id = updateGame.Id,
                Name = updateGame.Name.Trim(' '),
                Price = updateGame.Price,
                PublisherId = updateGame.PublisherId,
                GenreId = updateGame.GenreId.Distinct(),
            };
        }

        public static GameResponseDto MapToDto(this Game game, List<GenreResponseDto> genres, PublisherResponseDto publisher)
        {
            return new GameResponseDto
            {
                Id = game.Id,
                Name = game.Name.Trim(' '),
                Price = game.Price,
                Publisher = publisher,
                Genres = genres
            };
        }

        public static GameResponseDto MapToDto(this Game game)
        {
            return new GameResponseDto
            {
                Id = game.Id,
                Name = game.Name.Trim(' '),
                Price = game.Price
            };
        }
    }
}