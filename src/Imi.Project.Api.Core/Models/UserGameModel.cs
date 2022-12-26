using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services.Models
{
    public class UserGameModel
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
    }
}
