using System;

namespace Imi.Project.Api.Core.Entities
{
    public class UserGame: BaseGameMTM
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}