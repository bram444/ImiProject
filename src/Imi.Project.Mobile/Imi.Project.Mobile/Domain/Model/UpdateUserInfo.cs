using System;
using System.Collections.Generic;

namespace Imi.Project.Mobile.Domain.Model
{
    public class UpdateUserInfo: BaseInfo
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Guid> GameId { get; set; }
        public bool ApprovedTerms { get; set; }
    }
}
