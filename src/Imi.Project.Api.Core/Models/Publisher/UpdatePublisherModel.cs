using System;

namespace Imi.Project.Api.Core.Models.Publisher
{
    public class UpdatePublisherModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}