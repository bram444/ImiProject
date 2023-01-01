using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dto.User
{
    public class UpdateUserRequestDto: BaseDto
    {
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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