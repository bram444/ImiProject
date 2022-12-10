using System.Collections.Generic;

namespace Imi.Project.Api.Core.Services
{
    public class ServiceResult<T>
    {
        public T Result { get; set; }
        public bool HasErrors { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}