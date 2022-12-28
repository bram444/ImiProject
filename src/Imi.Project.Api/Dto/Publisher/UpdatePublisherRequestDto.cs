using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dto.Publisher
{
    public class UpdatePublisherRequestDto:BaseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
