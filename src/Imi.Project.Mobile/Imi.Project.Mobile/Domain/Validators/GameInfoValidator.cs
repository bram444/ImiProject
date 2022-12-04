using FluentValidation;
using Imi.Project.Mobile.Domain.Models;
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

            RuleFor(gameinfo => gameinfo.PublisherId)
                .NotNull()
                .WithMessage("Please select a publisher")
                .NotEmpty()
                .WithMessage("Please select a publisher");

            RuleFor(gameInfo => gameInfo.Price)
                .NotEmpty()
                .WithMessage("Give a valid price")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price cannot be negative");
        }
    }
}
