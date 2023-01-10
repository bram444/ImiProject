using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dto.User
{
    public class UpdateUserRequestDto: BaseDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<Guid> GameId { get; set; }

        [Required]
        public bool ApprovedTerms { get; set; }
    }
}