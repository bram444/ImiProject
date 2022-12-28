using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class Publisher: BaseEntity
    {
        public string Country { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}