using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class PublisherRepository: BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IEnumerable<Publisher>> SearchAsync(string search)
        {
            try
            {
                return await GetAll()
                    .Where(p => p.Name.Contains(search.Trim().ToUpper())).AsNoTracking()
                    .ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong with getting publisher with name {search}", ex.InnerException);
            }
        }

        public virtual async Task<IEnumerable<Publisher>> SearchByCountryAsync(string country)
        {
            try
            {
                return await GetAll()
                    .Where(p => p.Country.Contains(country.Trim().ToUpper())).AsNoTracking()
                    .ToListAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Something went wrong with getting publisher with country {country}", ex.InnerException);
            }
        }
    }
}