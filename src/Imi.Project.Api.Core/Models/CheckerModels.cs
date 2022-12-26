using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Models
{
    public class CheckerModels
    {
        public List<ValidationResult> ValidationErrors { get; set; } = new List<ValidationResult>();
        public bool IsOkay { get; set; }
    }
}
