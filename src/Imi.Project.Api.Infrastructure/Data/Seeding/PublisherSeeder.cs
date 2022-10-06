using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class PublisherSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(
               new[]
               {
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name="Bethesda",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="America"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name="Nintendo",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="Japan"
                    },
                }
                );
        }
    }
}