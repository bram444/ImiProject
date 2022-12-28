using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Models.UserGame
{
    public class UpdateUserGameModel
    {
        public Guid UserId { get; set; }
        public IEnumerable<Guid> GameIds { get; set; }
    }
}
