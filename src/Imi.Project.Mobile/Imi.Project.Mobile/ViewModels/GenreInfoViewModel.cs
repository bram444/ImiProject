using FluentValidation;
using FluentValidation.Results;
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
    public class GenreInfoViewModel: BaseListInfoViewModel<GenreInfo, IGenreService, IGameService, NewGenreInfo, UpdateGenreInfo>
    {
        public GenreInfoViewModel(IGenreService genreService, IGameService gameService)
            : base(genreService, gameService, new GenreInfoValidator(), new GenreInfoValidator())
        { }

        #region Properties
        private string genreDescription;
        public string GenreDescription
        {
            get
            {
                return genreDescription;
            }

            set
            {
                genreDescription = value;
                RaisePropertyChanged(nameof(GenreDescription));
            }
        }
        #endregion

        public override ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
            {
                base.AddCommand.Execute(null);

                if(GenreDescription == null)
                {
                    GenreDescription = string.Empty;
                }

                NewGenreInfo genreEdit = new NewGenreInfo
                {
                    Name = Name,
                    Description = GenreDescription
                };
                ApiResponse<GenreInfo> apiResponse = await AddItem(genreEdit);
                ErrorAPI = string.Join(Environment.NewLine, apiResponse.Messages);
            });
            }
        }

        public override ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
            {
                UpdateGenreInfo validateGenre = new UpdateGenreInfo
                {
                    Id = CurrentItem.Id,
                    Name = Name,
                    Description = GenreDescription,
                };

                ApiResponse<GenreInfo> apiResponse = await SaveItem(validateGenre);
                ErrorAPI = string.Join(Environment.NewLine, apiResponse.Messages);

            });
            }
        }

        public override bool Validate(NewGenreInfo genreInfo)
        {
            ValidationContext<NewGenreInfo> validationContext = new ValidationContext<NewGenreInfo>(genreInfo);
            ValidationResult validationResult = NewValidator.Validate(validationContext);

            foreach(ValidationFailure error in validationResult.Errors)
            {
                if(error.PropertyName == nameof(genreInfo.Name))
                {
                    NameError = error.ErrorMessage;
                }
            }

            return validationResult.IsValid;
        }

        public override bool Validate(UpdateGenreInfo genreInfo)
        {
            ValidationContext<UpdateGenreInfo> validationContext = new ValidationContext<UpdateGenreInfo>(genreInfo);
            ValidationResult validationResult = UpdateValidator.Validate(validationContext);

            foreach(ValidationFailure error in validationResult.Errors)
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

            Games = allGames.Where(gamess => gamess.Genres.Any(genre => genre.Id == CurrentItem.Id)).ToList();

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + CurrentItem.Name;

            base.SetEdit();
        }
    }
}