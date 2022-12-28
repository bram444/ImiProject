using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Models.GameGenre
{
    public class UpdateGameGenreModel
    {
        public Guid GameId { get; set; }
        public IEnumerable<Guid> GenreIds { get; set; }
    }
}
