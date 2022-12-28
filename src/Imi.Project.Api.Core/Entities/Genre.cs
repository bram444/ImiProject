using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class Genre: BaseEntity
    {
        public string Description { get; set; }
    }
}