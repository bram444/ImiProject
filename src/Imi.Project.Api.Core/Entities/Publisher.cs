using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class Publisher : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
