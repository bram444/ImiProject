using Imi.Project.Api.Dto.Genre;
using Imi.Project.Api.Dto.Publisher;

namespace Imi.Project.Api.Dto.Game
{
    public class GameResponseDto: BaseDto
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public PublisherResponseDto Publisher { get; set; }

        public ICollection<GenreResponseDto> Genres { get; set; }
    }
}