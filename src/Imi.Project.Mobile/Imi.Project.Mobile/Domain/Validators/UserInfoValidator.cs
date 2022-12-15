using FluentValidation;
using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Validators
{
    public class UserInfoValidator: AbstractValidator<UserInfo>
    {
        public UserInfoValidator()
        {
            RuleFor(userInfo => userInfo.Email)
                .NotEmpty()
                .WithMessage("Please enter your e-mail address")
                .EmailAddress()
                .WithMessage("Please enter a valid e-mail address");

            RuleFor(userInfo => userInfo.UserName)
                .NotEmpty()
                .WithMessage("Username cannot be empty");

            RuleFor(userInfo => userInfo.FirstName)
                .NotEmpty()
                .WithMessage("Firstname cannot be empty");

            RuleFor(userInfo => userInfo.LastName)
                .NotEmpty()
                .WithMessage("Lastname cannot be empty");

            RuleFor(userinfo => userinfo.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty")
                .MinimumLength(6)
                .WithMessage("Password must be longer than 6")
                .MaximumLength(100)
                .WithMessage("Password must be shorter than 100");

            RuleFor(userInfo => userInfo.ConfirmPassword)
                .Equal(userinfo => userinfo.Password)
                .WithMessage("Password must be the same as confirm password");


        }
    }
}