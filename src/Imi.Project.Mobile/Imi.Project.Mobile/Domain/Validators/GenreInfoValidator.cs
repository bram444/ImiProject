using FluentValidation;
using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Validators
{
    public class GenreInfoValidator: AbstractValidator<GenreInfo>
    {
        public GenreInfoValidator()
        {
            RuleFor(genreinfo => genreinfo.Name)
                 .NotEmpty()
                 .WithMessage("Genre name cannot be empty");
        }
    }
}