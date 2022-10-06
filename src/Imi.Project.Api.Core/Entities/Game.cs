using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class Game:BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public float Price { get; set; }

        [Required]
        public Guid PublisherId { get; set; }

        public Publisher Publisher { get; set; }

    }
}
