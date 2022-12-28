using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
