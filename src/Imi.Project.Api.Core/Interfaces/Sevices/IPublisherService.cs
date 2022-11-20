using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherResponseDto>> SearchAsync(string search);
        Task<IEnumerable<PublisherResponseDto>> SearchByCountryAsync(string country);

        IQueryable<PublisherResponseDto> GetAll();
        Task<IEnumerable<PublisherResponseDto>> ListAllAsync();
        Task<PublisherResponseDto> GetByIdAsync(Guid id);
        Task<ServiceResult<PublisherResponseDto>> UpdateAsync(PublisherResponseDto response);
        Task<ServiceResult<PublisherResponseDto>> AddAsync(PublisherResponseDto response);
        Task<ServiceResult<PublisherResponseDto>> DeleteAsync(Guid id);
    }
}