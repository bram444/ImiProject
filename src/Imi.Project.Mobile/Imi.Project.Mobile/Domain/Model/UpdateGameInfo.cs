using System;
using System.Collections.Generic;

namespace Imi.Project.Mobile.Domain.Model
{
    public class UpdateGameInfo: BaseInfo
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid PublisherId { get; set; }
        public ICollection<Guid> GenreId { get; set; }
    }
}
