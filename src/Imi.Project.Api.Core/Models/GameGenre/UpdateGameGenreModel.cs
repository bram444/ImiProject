using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Models.GameGenre
{
    public class UpdateGameGenreModel: BaseGameMTMModel
    {
        public IEnumerable<Guid> GenreIds { get; set; }
    }
}