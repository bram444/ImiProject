using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> SearchAsync(string search);
        Task<IEnumerable<Publisher>> SearchByCountryAsync(string country);

        IQueryable<Publisher> GetAll();
        Task<IEnumerable<Publisher>> ListAllAsync();
        Task<Publisher> GetByIdAsync(Guid id);
        Task<Publisher> UpdateAsync(PublisherResponseDto entity);
        Task<Publisher> AddAsync(PublisherResponseDto entity);
        Task<Publisher> DeleteAsync(PublisherResponseDto entity);
    }
}
