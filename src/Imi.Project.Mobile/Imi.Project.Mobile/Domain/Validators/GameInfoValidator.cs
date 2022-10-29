using FluentValidation;
using Imi.Project.Mobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Validators
{
    public class GameInfoValidator : AbstractValidator<GamesInfo>
    {
        public GameInfoValidator()
        {
            RuleFor(gameinfo => gameinfo.Name)
                .NotEmpty()
                .WithMessage("Game name cannot be empty");
        }
    }
}
