using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Models.Game
{
    public class UpdateGameModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public Guid PublisherId { get; set; }

        public IEnumerable<Guid> GenreId { get; set; }
    }
}