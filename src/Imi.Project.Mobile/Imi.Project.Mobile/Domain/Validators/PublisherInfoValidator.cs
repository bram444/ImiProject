using FluentValidation;
using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Validators
{
    public class PublisherInfoValidator: AbstractValidator<PublisherInfo>
    {
        public PublisherInfoValidator()
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