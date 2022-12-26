using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dto.Game
{
    public class GameDto: BaseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(float.Epsilon, float.MaxValue)]
        public float Price { get; set; }

        [Required]
        public Guid PublisherId { get; set; }

        [Required]
        public ICollection<Guid> GenreId { get; set; }
    }
}