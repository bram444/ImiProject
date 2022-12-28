using Imi.Project.Api.Dto.Game;

namespace Imi.Project.Api.Dto.User
{
    public class UserResponseDto:BaseDto
    {
        public string Password { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<GameResponseDto> Games { get; set; }

        public bool ApprovedTerms { get; set; }

        public DateTime BirthDay { get; set; }
    }
}