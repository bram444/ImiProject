using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class GameSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new[]
                {
                    new Game
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name= "Fallout New Vegas",
                        Price= 14.99f,
                        PublisherId=Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        CreatedOn=DateTime.Now,
                        LastEditedOn=DateTime.Now

                    },
                    new Game
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name= "Splatoon 3",
                        Price= 59.99f,
                        PublisherId=Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        CreatedOn=DateTime.Now,
                        LastEditedOn=DateTime.Now
                    },
                    new Game
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name= "Animal Crossing",
                        Price= 59.99f,
                        PublisherId=Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        CreatedOn=DateTime.Now,
                        LastEditedOn=DateTime.Now
                    }
                }
                );
        }
    }
}
