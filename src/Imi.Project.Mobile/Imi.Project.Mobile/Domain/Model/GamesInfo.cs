using System.Collections.Generic;

namespace Imi.Project.Mobile.Domain.Model
{
    public class GamesInfo: BaseInfo
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public PublisherInfo Publisher { get; set; }
        public ICollection<GenreInfo> Genres { get; set; }
    }
}