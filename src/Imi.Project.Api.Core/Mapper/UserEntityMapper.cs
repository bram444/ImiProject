using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.User;
using Microsoft.AspNetCore.Identity;
using System;

namespace Imi.Project.Api.Core.Mapper
{
    public static class UserEntityMapper
    {
        private static readonly IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

        public static ApplicationUser MapToEntity(this NewUserModel newUser)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = newUser.UserName,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                BirthDay = newUser.BirthDay,
                ApprovedTerms = newUser.ApprovedTerms,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = newUser.Email.Normalize(),
                NormalizedUserName = newUser.UserName.Normalize(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            user.PasswordHash = passwordHasher.HashPassword(user, newUser.Password);

            return user;
        }

        public static ApplicationUser MapToEntity(this UpdateUserModel updateUser, ApplicationUser oldUser)
        {
            var user = oldUser;

            user.UserName = updateUser.UserName;
            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.ApprovedTerms = updateUser.ApprovedTerms;
            user.NormalizedUserName = updateUser.UserName.Normalize();

            user.PasswordHash = passwordHasher.HashPassword(user, updateUser.Password);

            return user;
        }
    }
}