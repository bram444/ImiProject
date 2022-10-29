using FluentValidation;
using Imi.Project.Mobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Validators
{
    public  class GenreInfoValidator : AbstractValidator<GenreInfo>
    {
        public GenreInfoValidator()
        {
            RuleFor(genreinfo => genreinfo.Name)
                 .NotEmpty()
                 .WithMessage("Genre name cannot be empty");
        }
    }
}
