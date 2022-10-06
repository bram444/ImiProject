using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class GenreSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new[]
                {
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name="FPS",
                        Description="Fist person shooter",
                        LastEditedOn= DateTime.Now,
                        CreatedOn=DateTime.Now
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name="Third person shooter",
                        Description="Fist person shooter but in the third person",
                        LastEditedOn= DateTime.Now,
                        CreatedOn=DateTime.Now
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name="Simulation",
                        LastEditedOn= DateTime.Now,
                        CreatedOn=DateTime.Now
                    }
                }
                );
        }
    }
}