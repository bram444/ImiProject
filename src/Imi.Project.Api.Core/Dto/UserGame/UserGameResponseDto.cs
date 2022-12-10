using System;

namespace Imi.Project.Api.Core.Dto.UserGame
{
    public class UserGameResponseDto
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
    }
}