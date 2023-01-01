﻿using System;

namespace Imi.Project.Api.Core.Models.User
{
    public class NewUserModel
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool ApprovedTerms { get; set; }

        public DateTime BirthDay { get; set; }
    }
}