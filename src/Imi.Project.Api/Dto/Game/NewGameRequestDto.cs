using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dto.Game
{
    public class NewGameRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(float.Epsilon, float.MaxValue)]
        public float Price { get; set; }

        [Required]
        public Guid PublisherId { get; set; }

        public ICollection<Guid> GenreId { get; set; }
    }
}