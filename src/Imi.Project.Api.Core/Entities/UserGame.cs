using System;

namespace Imi.Project.Api.Core.Entities
{
    public class UserGame
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}