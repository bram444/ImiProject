using FluentValidation;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GenreInfoViewModel: BaseListInfoViewModel<GenreInfo, IGenreService, IGameService>
    {
        public GenreInfoViewModel(IGenreService genreService, IGameService gameService)
            : base(genreService, gameService, new GenreInfoValidator())
        { }

        #region Properties
        private string genreDescription;
        public string GenreDescription
        {
            get => genreDescription;
            set
            {
                genreDescription = value;
                RaisePropertyChanged(nameof(GenreDescription));
            }
        }
        #endregion

        public override ICommand AddCommand => new Command(() =>
            {
                base.AddCommand.Execute(null);

                if(GenreDescription == null)
                {
                    GenreDescription = string.Empty;
                }

                GenreInfo genreEdit = new GenreInfo
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    Description = GenreDescription
                };

                AddItem(genreEdit);
            });

        public override ICommand SaveCommand => new Command(() =>
            {
                GenreInfo validateGenre = new GenreInfo
                {
                    Id = CurrentItem.Id,
                    Name = Name,
                    Description = GenreDescription,
                };

                SaveItem(validateGenre);
            });

        public override bool Validate(GenreInfo genreInfo)
        {
            ValidationContext<GenreInfo> validationContext = new ValidationContext<GenreInfo>(genreInfo);
            FluentValidation.Results.ValidationResult validationResult = InfoValidator.Validate(validationContext);

            foreach(FluentValidation.Results.ValidationFailure error in validationResult.Errors)
            {
                if(error.PropertyName == nameof(genreInfo.Name))
                {
                    NameError = error.ErrorMessage;
                }
            }

            return validationResult.IsValid;
        }

        public override void SetAdd()
        {
            Title = "New genre";

            base.SetAdd();
        }

        public override async void SetRead()
        {
            Title = CurrentItem.Name;
            GenreDescription = CurrentItem.Description;
            Name = CurrentItem.Name;

            IEnumerable<GamesInfo> allGames = await ListService.GetAll();

            Games = allGames.Where(gamess => gamess.GenreId.Contains(CurrentItem.Id)).ToList();

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + CurrentItem.Name;

            base.SetEdit();
        }
    }
}