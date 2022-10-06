using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class UserGameSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGame>().HasData(
               new[]
               {
                    new UserGame
                    {
                        UserId=Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        GameId=Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },
                    new UserGame
                    {
                        UserId=Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        GameId=Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    new UserGame
                    {
                        UserId=Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        GameId=Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new UserGame
                    {
                        UserId=Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        GameId=Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
               }
               );
        }
    }
}
