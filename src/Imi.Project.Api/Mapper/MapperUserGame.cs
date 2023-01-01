using Imi.Project.Api.Core.Models.UserGame;
using Imi.Project.Api.Dto.User;

namespace Imi.Project.Api.Mapper
{
    public static class MapperUserGame
    {
        //public static UserGameModel UserGameModelMapper(Guid userId, Guid gameId)
        //{
        //    return new UserGameModel
        //    {
        //        UserId = userId,
        //        GameId = gameId
        //    };
        //}

        //public static UserGameModel UserGameModelMapper(UserGame userGame)
        //{
        //    return new UserGameModel
        //    {
        //        UserId = userGame.UserId,
        //        GameId = userGame.GameId
        //    };
        //}

        public static UpdateUserGameModel MapToUserGameModel(this UpdateUserRequestDto updateUserRequest)
        {
            return new UpdateUserGameModel
            {
                UserId = updateUserRequest.Id,
                GameIds = updateUserRequest.GameId.Distinct()
            };
        }
    }
}