using System;

namespace Imi.Project.Api.Core.Entities
{
    public class GameGenre: BaseGameMTM
    {
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}