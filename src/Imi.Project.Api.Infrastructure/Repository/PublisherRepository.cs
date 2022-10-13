﻿using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repository
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Publisher>> SearchAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Publisher>> SearchByCountryAsync(string country)
        {
            throw new NotImplementedException();
        }
    }
}
