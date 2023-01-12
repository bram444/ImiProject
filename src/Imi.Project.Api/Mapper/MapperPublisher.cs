using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Publisher;
using Imi.Project.Api.Dto.Publisher;

namespace Imi.Project.Api.Mapper
{
    public static class MapperPublisher
    {
        public static NewPublisherModel MapToModel(this NewPublisherRequestDto newPublisher)
        {
            return new NewPublisherModel
            {
                Country = newPublisher.Country.Trim(' '),
                Name = newPublisher.Name.Trim(' '),
            };
        }

        public static UpdatePublisherModel MapToModel(this UpdatePublisherRequestDto updatePublisher)
        {
            return new UpdatePublisherModel
            {
                Id = updatePublisher.Id,
                Name = updatePublisher.Name.Trim(' '),
                Country = updatePublisher.Country.Trim(' '),
            };
        }

        public static PublisherResponseDto MapToDto(this Publisher publisher)
        {
            return new PublisherResponseDto
            {
                Id = publisher.Id,
                Country = publisher.Country.Trim(' '),
                Name = publisher.Name.Trim(' '),
            };
        }

        public static IEnumerable<PublisherResponseDto> MapToDtos(this IEnumerable<Publisher> publishers)
        {
            return publishers.Select(publisher => publisher.MapToDto());
        }
    }
}