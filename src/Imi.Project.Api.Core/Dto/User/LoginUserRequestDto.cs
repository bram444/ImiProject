using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dto.User
{
    public class LoginUserRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
