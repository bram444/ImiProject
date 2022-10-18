using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dto.UserGame
{
    public class UserGameResponseDto
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
    }
}
