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
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name="Ubisoft",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="America"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name="Square inex",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="Japan"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name="Sony",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="America"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name="Microsoft",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="America"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name="The pokemon company",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="Japan"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name="CD project",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="Sweden"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name="Arc System Works",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="Japan"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name="Interplay Entertainment",
                        CreatedOn = DateTime.Now,
                        LastEditedOn = DateTime.Now,
                        Country="America"
                    },
                }
                );
        }
    }
}