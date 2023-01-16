using FluentValidation;
using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Validators
{
    public class UpdateUserInfoValidator: AbstractValidator<UpdateUserInfo>
    {
        public UpdateUserInfoValidator()
        {
            RuleFor(userInfo => userInfo.UserName)
                .NotEmpty()
                .WithMessage("Username cannot be empty");

            RuleFor(userInfo => userInfo.FirstName)
                .NotEmpty()
                .WithMessage("Firstname cannot be empty");

            RuleFor(userInfo => userInfo.LastName)
                .NotEmpty()
                .WithMessage("Lastname cannot be empty");
        }
    }
}