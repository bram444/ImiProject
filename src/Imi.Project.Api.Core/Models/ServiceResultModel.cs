using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Services.Models
{
    public class ServiceResultModel<T> where T : class
    {
        public IList<ValidationResult> ValidationErrors { get; set; } = new List<ValidationResult>();
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
