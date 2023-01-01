using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities
{
    public class Publisher: BaseEntity
    {
        public string Country { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}