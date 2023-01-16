using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dto.Authentication
{
    public class RegistrationDto
    {
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [RegularExpression("^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{6,100}$", ErrorMessage = "Password needs a big and small letter, a number and a special character")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        [Required]
        public bool ApprovedTerms { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }
    }
}