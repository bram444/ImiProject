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
            modelBuilder.Entity<ApplicationUser>().HasData(
                new[]
                {
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserName="FirstUser",
                        FirstName="First",
                        LastName="User",
                        Email="FirstUser@gmail.com",
                        LastEditedOn=DateTime.Now,
                        CreatedOn=DateTime.Now,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserName="TimTheDestroyerXx400",
                        FirstName="Second",
                        LastName="User",
                        Email="SecondUser@gmail.com",
                        LastEditedOn=DateTime.Now,
                        CreatedOn=DateTime.Now,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserName="UserTheThird",
                        FirstName="Third",
                        LastName="User",
                        Email="ThirdUser@gmail.com",
                        LastEditedOn=DateTime.Now,
                        CreatedOn=DateTime.Now,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        UserName="UserTheFourth",
                        FirstName="Fourth",
                        LastName="User",
                        Email="FourthUser@gmail.com",
                        LastEditedOn=DateTime.Now,
                        CreatedOn=DateTime.Now,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        UserName = "UserTheFifth",
                        FirstName = "Fifth",
                        LastName = "User",
                        Email = "FifthUser@gmail.com",
                        LastEditedOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        UserName = "UserTheSith",
                        FirstName = "Six",
                        LastName = "User",
                        Email = "SixUser@gmail.com",
                        LastEditedOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        UserName = "UserTheSeven",
                        FirstName = "Seven",
                        LastName = "User",
                        Email = "SevenUser@gmail.com",
                        LastEditedOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        UserName = "UserTheEigth",
                        FirstName = "Eigth",
                        LastName = "User",
                        Email = "EigthUser@gmail.com",
                        LastEditedOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        UserName = "UserTheNinth",
                        FirstName = "Ninth",
                        LastName = "User",
                        Email = "NinthUser@gmail.com",
                        LastEditedOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        UserName = "UserX",
                        FirstName = "X",
                        LastName = "User",
                        Email = "XUser@gmail.com",
                        LastEditedOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                    },
                }
                );
        }
    }
}
