using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Models.Publisher
{
    public class NewPublisherModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
