using Microsoft.AspNetCore.Identity;
using System;

namespace Imi.Project.Api.Core.Entities
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool ApprovedTerms { get; set; }

        public DateTime BirthDay { get; set; }
    }
}