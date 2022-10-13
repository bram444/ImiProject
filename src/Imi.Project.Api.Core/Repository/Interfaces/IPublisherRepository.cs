using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Repository.Interfaces
{
    public interface IPublisherRepository : IBaseRepository<Publisher>
    {
        Task<IEnumerable<Publisher>> SearchAsync(string search);
        Task<IEnumerable<Publisher>> SearchByCountryAsync(string country);
    }
}
