﻿using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
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
            List<Publisher> publisher = await GetAll()
                .Where(p => p.Name.Contains(search.Trim().ToUpper()))
                .ToListAsync();

            return publisher;
        }

        public virtual async Task<IEnumerable<Publisher>> SearchByCountryAsync(string country)
        {
            List<Publisher> publisher = await GetAll()
                .Where(p => p.Country.Contains(country.Trim().ToUpper()))
                .ToListAsync();

            return publisher;
        }
    }
}