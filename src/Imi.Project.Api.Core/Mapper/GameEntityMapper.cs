using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Game;
using System;

namespace Imi.Project.Api.Core.Mapping
{
    public static class GameEntityMapper
    {
        public static Game MapToEntity(this NewGameModel newGame)
        {
            return new Game
            {
                 Id = Guid.NewGuid(),
                 Name = newGame.Name,
                 Price = newGame.Price,
                  PublisherId = newGame.PublisherId,
            };
        }

        public static Game MapToEntity(this UpdateGameModel updateGame)
        {
            return new Game
            {
                Id = updateGame.Id,
                Name = updateGame.Name,
                Price = updateGame.Price,
                PublisherId = updateGame.PublisherId
            };
        }
    }
}
