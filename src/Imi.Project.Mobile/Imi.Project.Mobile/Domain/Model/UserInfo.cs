using System;
using System.Collections.Generic;

namespace Imi.Project.Mobile.Domain.Model
{
    public class UserInfo: BaseInfo
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public ICollection<GamesInfo> Games { get; set; }
        public bool ApprovedTerms { get; set; }
        public DateTime BirthDay { get; set; }
    }
}