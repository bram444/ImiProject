using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dto.Authentication
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}