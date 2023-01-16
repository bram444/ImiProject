using System.Collections.Generic;

namespace Imi.Project.Api.Core.Models
{
    public class ServiceResultModel<T> where T : class
    {
        public List<string> ValidationErrors { get; set; } = new List<string>();
        public T Data { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}