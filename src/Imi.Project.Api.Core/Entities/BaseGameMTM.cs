using System;

namespace Imi.Project.Api.Core.Entities
{
    public class BaseGameMTM//Base of many to mant relationships with Game
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
