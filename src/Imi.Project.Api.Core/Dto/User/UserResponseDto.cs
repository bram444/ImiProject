using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Dto.User
{
    public class UserResponseDto
    {
        [Required]
        public Guid Id { get; set; }

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

        [Required]
        public string Email { get; set; }

        public ICollection<Guid> GameId { get; set; }
    }
}