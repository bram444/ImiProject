using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dto.Genre
{
    public class GenreDto: BaseDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}