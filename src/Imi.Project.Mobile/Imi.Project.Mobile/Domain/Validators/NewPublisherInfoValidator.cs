using FluentValidation;
using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Validators
{
    public class NewPublisherInfoValidator: AbstractValidator<NewPublisherInfo>
    {
        public NewPublisherInfoValidator()
        {
            RuleFor(publisherInfo => publisherInfo.Name)
                 .NotEmpty()
                 .WithMessage("Publisher name cannot be empty");

            RuleFor(publisherInfo => publisherInfo.Country)
                .NotEmpty()
                .WithMessage("Country cannot be empty");
        }
    }
}
