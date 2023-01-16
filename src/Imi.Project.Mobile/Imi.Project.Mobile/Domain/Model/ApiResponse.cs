using System.Collections.Generic;

namespace Imi.Project.Mobile.Domain.Model
{
    public class ApiResponse<T>
    {
        public T ApiResponseData { get; set; }
        public bool IsSuccess { get; set; } = true;
        public IEnumerable<string> Messages { get; set; } = new List<string>();
    }
}
