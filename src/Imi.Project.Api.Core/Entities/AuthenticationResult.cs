using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool IsSuccess { get; set; } = true;
        public IEnumerable<string> Messages { get; set; } = new List<string>();
    }
}