using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.UserGame;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imi.Project.Api.Core.Mapper
{
    public static class UserGameEntityMapper
    {
        public static UserGame MapToEntity(this UserGameModel userGameModel)
        {
            return new UserGame
            {
                GameId = userGameModel.GameId,
                UserId = userGameModel.UserId
            };
        }

        public static UserGameModel MapToModel(this UserGame userGame)
        {
            return new UserGameModel
            {
                GameId = userGame.GameId,
                UserId = userGame.UserId
            };
        }

        public static UserGameModel MapToModel(Guid userId, Guid gameId)
        {
            return new UserGameModel
            {
                UserId = userId,
                GameId = gameId
            };
        }

        public static IEnumerable<UserGameModel> MapToModel(this IEnumerable<UserGame> userGames)
        {
            return userGames.Select(gg => gg.MapToModel());
        }

        //public static IEnumerable<UserGame> MapToEntity(this IEnumerable<UserGameModel> userGameModels)
        //{
        //    return userGameModels.Select(gg => gg.MapToEntity());
        //}
    }
}