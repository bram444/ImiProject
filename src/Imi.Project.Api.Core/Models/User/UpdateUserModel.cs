using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Models.User
{
    public class UpdateUserModel
    {
        public Guid Id { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<Guid> GameId { get; set; }

        public bool ApprovedTerms { get; set; }
    }
}