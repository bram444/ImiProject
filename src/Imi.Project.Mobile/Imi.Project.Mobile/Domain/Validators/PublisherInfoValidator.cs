using FluentValidation;
using Imi.Project.Mobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Validators
{
    public class PublisherInfoValidator : AbstractValidator<PublisherInfo>
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
