using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GenreInfoViewModel: BaseInfoViewModel
    {
        private GenreInfo currentGenreInfo;
        private readonly IGenreService genreService;

        public GenreInfoViewModel(IGenreService genreService, IGameService gameService)
            :base(gameService)
        {
            this.genreService = genreService;

            InfoValidator = new GenreInfoValidator();
        }

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

        private IEnumerable<GamesInfo> games;
        public IEnumerable<GamesInfo> Games
        {
            get => games;
            set
            {
                games = value;
                RaisePropertyChanged(nameof(Games));
            }
        }

        private bool enableGameList;
        public bool EnableGameList
        {
            get => enableGameList;
            set
            {
                enableGameList = value;
                RaisePropertyChanged(nameof(EnableGameList));
            }
        }

        #endregion

        public override void Init(object initData)
        {
            if(initData != null)
            {
                currentGenreInfo = initData as GenreInfo;

                SetRead();
            } else
            {
                SetAdd();
            }

            base.Init(initData);
        }

        public ICommand SaveGenreInfoCommand => new Command(
            async () =>
            {
                GenreInfo validateGenre = new GenreInfo
                {
                    Id = currentGenreInfo.Id,
                    Name = Name,
                    Description = GenreDescription,
                };

                if(Validate(validateGenre))
                {
                    await genreService.UpdateGenre(validateGenre);
                    await CoreMethods.PopPageModel(validateGenre, false, true);
                }
            });

        public ICommand AddGenreInfoCommand => new Command(
            async () =>
            {
                if(this.Name == null)
                {
                    this.Name = "";
                }

                if(GenreDescription == null)
                {
                    GenreDescription = "";
                }

                GenreInfo genreEdit = new GenreInfo
                {
                    Id = Guid.NewGuid(),
                    Name = this.Name,
                    Description = GenreDescription
                };

                if(Validate(genreEdit))
                {
                    await genreService.AddGenre(genreEdit);
                    await CoreMethods.PopPageModel(genreEdit, false, true);
                }
            });

        public ICommand EditCommand => new Command(() =>
        {
            SetEdit();
        });

        public ICommand CancelCommand => new Command(() =>
        {
            SetRead();
        });

        public ICommand DeleteCommand => new Command(async () =>
        {
            if(DeviceInfo.Platform == DevicePlatform.Android)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
            }

            await genreService.DeleteGenre(currentGenreInfo.Id);
            await CoreMethods.PopPageModel(new GenreInfo(), false, true);
        });

        private bool Validate(GenreInfo genreInfo)
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
            Title = "New Genre";

            EnableGameList = false;

            base.SetAdd();
        }

        public override async void SetRead()
        {
            GenreDescription = currentGenreInfo.Description;
            Name = currentGenreInfo.Name;

            Title = currentGenreInfo.Name;

            EnableGameList = true;

            IEnumerable<GamesInfo> allGames = await GameService.GetAllGames();

            Games = allGames.Where(gamess => gamess.GenreId.Contains(currentGenreInfo.Id)).ToList();

            if(Games.Count() == 0)
            {
                EnableGameList = false;
            }

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + currentGenreInfo.Name;

            base.SetEdit();
        }
    }
}