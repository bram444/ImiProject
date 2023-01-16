using System.Collections.Generic;

namespace Imi.Project.Mobile.Domain.Model
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public bool IsSuccess { get; set; } = true;
        public IEnumerable<string> Messages { get; set; } = new List<string>();
    }
}
