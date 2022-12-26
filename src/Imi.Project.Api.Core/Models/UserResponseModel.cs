using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services.Models
{
    public class UserResponseModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<Guid> GameId { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
