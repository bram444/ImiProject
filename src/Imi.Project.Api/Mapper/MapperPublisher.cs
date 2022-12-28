using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Publisher;
using Imi.Project.Api.Dto.Genre;
using Imi.Project.Api.Dto.Publisher;

namespace Imi.Project.Api.Mapper
{
    public static class MapperPublisher
    {
        public static NewPublisherModel NewPublisherModelMapper(this NewPublisherRequestDto newPublisher)
        {
            return new NewPublisherModel
            {
                Country = newPublisher.Country,
                Name = newPublisher.Name,
            };
        }

        public static UpdatePublisherModel UpdatePublisherModelMapper(this UpdatePublisherRequestDto updatePublisher)
        {
            return new UpdatePublisherModel
            {
                Id = updatePublisher.Id,
                Name = updatePublisher.Name,
                Country = updatePublisher.Country,
            };
        }

        public static PublisherResponseDto PublisherResponseDtoMapper(this Publisher publisher)
        {
            return new PublisherResponseDto
            {
                Id = publisher.Id,
                 Country = publisher.Country,
                  Name= publisher.Name,
            };
        }

        public static IEnumerable<PublisherResponseDto> PublisherResponseDtoMapper(this IEnumerable<Publisher> publishers)
        {
            return publishers.Select(publisher => publisher.PublisherResponseDtoMapper());
        }
    }
}