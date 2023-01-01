using System;

namespace Imi.Project.Api.Core.Models.UserGame
{
    public class UserGameModel: BaseGameMTMModel
    {
        public Guid UserId { get; set; }
    }
}