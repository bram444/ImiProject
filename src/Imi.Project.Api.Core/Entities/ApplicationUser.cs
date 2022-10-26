using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class ApplicationUser:BaseEntity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
