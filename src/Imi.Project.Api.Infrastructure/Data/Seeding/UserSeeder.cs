using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Guid AdminRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            const string AdminRoleName = "Admin";

            Guid UserRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            const string UserRoleName = "User";

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

            const string adminUserName = "admin";
            const string adminEmail = "admin@imi.be";

            const string userUserName = "user";
            const string userEmail = "user@imi.be";

            const string refuserUserName = "refuser";
            const string refuserEmail = "refuser@imi.be";

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
                        NormalizedUserName =firstUserName.Normalize(),
                        NormalizedEmail =firstEmail.Normalize(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Now
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserName=secondUserName,
                        FirstName="Second",
                        LastName="User",
                        Email=secondEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = secondEmail.Normalize(),
                        NormalizedUserName = secondUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2000")
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserName=thirdUserName,
                        FirstName="Third",
                        LastName="User",
                        Email=thirdEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = thirdEmail.Normalize(),
                        NormalizedUserName = thirdUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010")
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        UserName=forthUserName,
                        FirstName="Fourth",
                        LastName="User",
                        Email=forthEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = forthEmail.Normalize(),
                        NormalizedUserName = forthUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010")
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        UserName = fifthUserName,
                        FirstName = "Fifth",
                        LastName = "User",
                        Email = fifthEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = fifthEmail.Normalize(),
                        NormalizedUserName = fifthUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010")
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        UserName = sixUserName,
                        FirstName = "Six",
                        LastName = "User",
                        Email = sixEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = sixEmail.Normalize(),
                        NormalizedUserName = sixUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010")
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        UserName = seventhUserName,
                        FirstName = "Seven",
                        LastName = "User",
                        Email = seventhEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = seventhEmail.Normalize(),
                        NormalizedUserName = seventhUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010")
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        UserName = eigthUserName,
                        FirstName = "Eigth",
                        LastName = "User",
                        Email = eigthEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = eigthEmail.Normalize(),
                        NormalizedUserName = eigthUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010")
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        UserName = ninthUserName,
                        FirstName = "Ninth",
                        LastName = "User",
                        Email = ninthEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = ninthEmail.Normalize(),
                        NormalizedUserName = ninthUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010")
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        UserName = xUserName,
                        FirstName = "X",
                        LastName = "User",
                        Email = xEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = xEmail.Normalize(),
                        NormalizedUserName = xUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010"),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                        UserName = adminUserName,
                        FirstName = "ad",
                        LastName = "min",
                        Email = adminEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = adminEmail.Normalize(),
                        NormalizedUserName = adminUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010"),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                        UserName = userUserName,
                        FirstName = "us",
                        LastName = "er",
                        Email = userEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = userEmail.Normalize(),
                        NormalizedUserName = userUserName.Normalize(),
                        ApprovedTerms = true,
                        BirthDay = DateTime.Parse("19/08/2010"),
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                        UserName = refuserUserName,
                        FirstName = "ref",
                        LastName = "user",
                        Email = refuserEmail,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = refuserEmail.Normalize(),
                        NormalizedUserName = refuserUserName.Normalize(),
                        ApprovedTerms = false,
                        BirthDay = DateTime.Parse("19/08/2010"),
                    }
                };

            foreach(ApplicationUser user in applicationUsers)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, AdminUserPassword);
            }

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(new[] {
                new IdentityRole<Guid>
                {
                    Id = AdminRoleId,
                    Name = AdminRoleName,
                    NormalizedName = AdminRoleName.Normalize(),
                },
                new IdentityRole<Guid>()
                {
                    Id=UserRoleId,
                    Name=UserRoleName,
                    NormalizedName=UserRoleName.Normalize()
                }
            });

            modelBuilder.Entity<ApplicationUser>().HasData(applicationUsers);

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new[]
            {
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[0].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = AdminRoleId,
                UserId = applicationUsers[1].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[2].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[3].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = AdminRoleId,
                UserId = applicationUsers[4].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[5].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[6].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[7].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[8].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[9].Id,
                },
                                new IdentityUserRole<Guid>
                {
                RoleId = AdminRoleId,
                UserId = applicationUsers[10].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[11].Id,
                },
                new IdentityUserRole<Guid>
                {
                RoleId = UserRoleId,
                UserId = applicationUsers[12].Id,
                }
            });

            int id = 0;

            foreach(ApplicationUser user in applicationUsers)
            {
                modelBuilder.Entity<IdentityUserClaim<Guid>>().HasData(new[]
                {
                    new IdentityUserClaim<Guid>
                    {

                        UserId =user.Id,
                        ClaimType =ClaimTypes.DateOfBirth,
                        ClaimValue = user.BirthDay.ToShortDateString(),
                        Id = ++id
                    },
                    new IdentityUserClaim<Guid>
                    {
                        UserId =user.Id,
                        ClaimType ="approved",
                        ClaimValue = "True",
                        Id = ++id
                    },
                });
            }
        }
    }
}