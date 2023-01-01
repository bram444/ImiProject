using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Publisher;
using System;

namespace Imi.Project.Api.Core.Mapper
{
    public static class PublisherEntityMapper
    {
        public static Publisher MapToEntity(this NewPublisherModel newPublisher)
        {
            return new Publisher
            {
                Id = Guid.NewGuid(),
                Name = newPublisher.Name,
                Country = newPublisher.Country
            };
        }

        public static Publisher MapToEntity(this UpdatePublisherModel updatePublisher)
        {
            return new Publisher
            {
                Id = updatePublisher.Id,
                Name = updatePublisher.Name,
                Country = updatePublisher.Country
            };
        }
    }
}