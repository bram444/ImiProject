using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class AuthenticateResult
    {
        public string Token { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Messages { get; set; } = new List<string>();

    }
}