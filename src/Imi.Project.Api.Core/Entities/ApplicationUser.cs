using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class ApplicationUser: IdentityUser<Guid>
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}