using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Guid AdminRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            const string AdminRoleName = "Admin";

            const string firstUserName = "FirstGuy";
            const string firstEmail = "FirstUser@gmail.com";

            const string secondUserName = "TimTheDestroyerXx400";
            const string secondEmail = "SecondUser@gmail.com";

            const string thirdUserName = "UserTheThird";
            const string thirdEmail = "ThirdUser@gmail.com";

            const string forthUserName = "UserTheFourth";
            const string forthEmail = "FourthUser@gmail.com";

            const string fifthUserName = "UserTheFifth";
            const string fifthEmail = "FifthUser@gmail.com";

            const string sixUserName = "UserTheSith";
            const string sixEmail = "SixUser@gmail.com";

            const string seventhUserName = "UserTheSeven";
            const string seventhEmail = "SevenUser@gmail.com";

            const string eigthUserName = "UserTheEigth";
            const string eigthEmail = "EigthUser@gmail.com";

            const string ninthUserName = "UserTheNinth";
            const string ninthEmail = "NinthUser@gmail.com";

            const string xUserName = "UserX";
            const string xEmail = "XUser@gmail.com";

            const string AdminUserPassword = "Test123?";

            IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser[] applicationUsers =
                new[]
                {
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserName=firstUserName,
                        FirstName="First",
                        LastName="User",
                        Email="FirstUser@gmail.com",
                        NormalizedUserName =firstUserName.ToUpper(),
                        NormalizedEmail =firstEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58",
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserName=secondUserName,
                        FirstName="Second",
                        LastName="User",
                        Email=secondEmail,
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINB",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc59",
                        NormalizedEmail = secondEmail.ToUpper(),
                        NormalizedUserName = secondUserName.ToUpper(),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserName=thirdUserName,
                        FirstName="Third",
                        LastName="User",
                        Email=thirdEmail,
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINC",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc50",
                        NormalizedEmail = thirdEmail.ToUpper(),
                        NormalizedUserName = thirdUserName.ToUpper(),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        UserName=forthUserName,
                        FirstName="Fourth",
                        LastName="User",
                        Email=forthEmail,
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZIND",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc51",
                        NormalizedEmail = forthEmail.ToUpper(),
                        NormalizedUserName = forthUserName.ToUpper(),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        UserName = fifthUserName,
                        FirstName = "Fifth",
                        LastName = "User",
                        Email = fifthEmail,
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINE",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc52",
                        NormalizedEmail = fifthEmail.ToUpper(),
                        NormalizedUserName = fifthUserName.ToUpper(),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        UserName = sixUserName,
                        FirstName = "Six",
                        LastName = "User",
                        Email = sixEmail,
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINF",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc53",
                        NormalizedEmail = sixEmail.ToUpper(),
                        NormalizedUserName = sixUserName.ToUpper(),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        UserName = seventhUserName,
                        FirstName = "Seven",
                        LastName = "User",
                        Email = seventhEmail,
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZING",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc54",
                        NormalizedEmail = seventhEmail.ToUpper(),
                        NormalizedUserName = seventhUserName.ToUpper(),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        UserName = eigthUserName,
                        FirstName = "Eigth",
                        LastName = "User",
                        Email = eigthEmail,
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINH",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc55",
                        NormalizedEmail = eigthEmail.ToUpper(),
                        NormalizedUserName = eigthUserName.ToUpper(),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        UserName = ninthUserName,
                        FirstName = "Ninth",
                        LastName = "User",
                        Email = ninthEmail,
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINI",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc56",
                        NormalizedEmail = ninthEmail.ToUpper(),
                        NormalizedUserName = ninthUserName.ToUpper(),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        UserName = xUserName,
                        FirstName = "X",
                        LastName = "User",
                        Email = xEmail,
                        EmailConfirmed = true,
                        SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINJ",
                        ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc57",
                        NormalizedEmail = xEmail.ToUpper(),
                        NormalizedUserName = xUserName.ToUpper(),
                    }
                };

            foreach(ApplicationUser user in applicationUsers)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, AdminUserPassword);
            }

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
            {
                Id = AdminRoleId,
                Name = AdminRoleName,
                NormalizedName = AdminRoleName.ToUpper()
            });

            modelBuilder.Entity<ApplicationUser>().HasData(applicationUsers);

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new[]
            {
                new IdentityUserRole<Guid>
                {
                RoleId = AdminRoleId,
                UserId = applicationUsers[0].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = AdminRoleId,
                UserId = applicationUsers[4].Id,
                }
            });
        }
    }
}