using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services.Models
{
    public class UserRequestModel
    {
        public Guid Id { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<Guid> GameId { get; set; }

        public bool ApprovedTerms { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
