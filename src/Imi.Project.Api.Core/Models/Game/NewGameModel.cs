using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Models.Game
{
    public class NewGameModel
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public Guid PublisherId { get; set; }

        public IEnumerable<Guid> GenreId { get; set; }
    }
}
