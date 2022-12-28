using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
                        Country="America"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name="Nintendo",
                        Country="Japan"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name="Ubisoft",
                        Country="America"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name="Square inex",
                        Country="Japan"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name="Sony",
                        Country="America"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name="Microsoft",
                        Country="America"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name="The pokemon company",
                        Country="Japan"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name="CD project",
                        Country="Sweden"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "Arc System Works",
                        Country = "Japan"
                    },
                    new Publisher
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name = "Interplay Entertainment",
                        Country = "America"
                    },
                });
        }
    }
}