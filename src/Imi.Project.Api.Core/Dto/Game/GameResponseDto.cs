using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Dto.Game
{
    public class GameResponseDto: BaseDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid PublisherId { get; set; }
        public ICollection<Guid> GenreId { get; set; }
    }
}