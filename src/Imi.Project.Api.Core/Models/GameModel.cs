using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services.Models
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }

        public Guid PublisherId { get; set; }

        public ICollection<Guid> GenreId { get; set; }
    }
}
