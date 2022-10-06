using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new[]
                {
                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserName="FirstUser",
                        FirstName="First",
                        LastName="User",
                        Email="FirstUser@gmail.com",
                        LastEditedOn=DateTime.Now,
                        CreatedOn=DateTime.Now,
                    },
                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserName="TimTheDestroyerXx400",
                        FirstName="Second",
                        LastName="User",
                        Email="SecondUser@gmail.com",
                        LastEditedOn=DateTime.Now,
                        CreatedOn=DateTime.Now,
                    },
                }
                );
        }
    }
}
