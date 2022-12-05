using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GenreInfoViewModel : FreshBasePageModel
    {
        private GenreInfo currentGenreInfo;
        private readonly IValidator genreInfoValidator;

        private readonly IGenreService genreService;

        private readonly IGameService gameService;

        public GenreInfoViewModel(IGenreService genreService, IGameService gameService)
        {
            this.genreService = genreService;
            this.gameService = gameService;

            genreInfoValidator = new GenreInfoValidator();
        }

        #region Properties

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private string genreName;
        public string GenreName
        {
            get { return genreName; }
            set
            {
                genreName = value;
                GenreNameError = null;
                RaisePropertyChanged(nameof(GenreName));
            }
        }

        private string genreDescription;
        public string GenreDescription
        {
            get { return genreDescription; }
            set
            {
                genreDescription = value;
                RaisePropertyChanged(nameof(GenreDescription));
            }
        }

        private string genreNameError;
        public string GenreNameError
        {
            get { return genreNameError; }
            set
            {
                genreNameError = value;
                RaisePropertyChanged(nameof(GenreNameError));
                RaisePropertyChanged(nameof(GenreNameErrorVisible));

            }
        }

        public bool GenreNameErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(GenreNameError); }
        }

        private bool visableAdd;
        public bool VisableAdd
        {
            get { return visableAdd; }
            set
            {
                visableAdd = value;
                RaisePropertyChanged(nameof(VisableAdd));
            }
        }

        private bool visableCancel;
        public bool VisableCancel
        {
            get { return visableCancel; }
            set
            {
                visableCancel = value;
                RaisePropertyChanged(nameof(VisableCancel));
            }
        }

        private bool visableEdit;
        public bool VisableEdit
        {
            get { return visableEdit; }
            set
            {
                visableEdit = value;
                RaisePropertyChanged(nameof(VisableEdit));
            }
        }

        private bool visableDelete;
        public bool VisableDelete
        {
            get { return visableDelete; }
            set
            {
                visableDelete = value;
                RaisePropertyChanged(nameof(VisableDelete));
            }
        }

        private bool visableSave;
        public bool VisableSave
        {
            get { return visableSave; }
            set
            {
                visableSave = value;
                RaisePropertyChanged(nameof(VisableSave));
            }
        }

        private bool enableEditData;
        public bool EnableEditData
        {
            get { return enableEditData; }
            set
            {
                enableEditData = value;
                RaisePropertyChanged(nameof(EnableEditData));
            }
        }

        private IEnumerable<GamesInfo> games;
        public IEnumerable<GamesInfo> Games
        {
            get { return games; }
            set
            {
                games = value;
                RaisePropertyChanged(nameof(Games));
            }
        }

        private bool enableGameList;
        public bool EnableGameList
        {
            get { return enableGameList; }
            set
            {
                enableGameList = value;
                RaisePropertyChanged(nameof(EnableGameList));
            }
        }

        #endregion

        public override void Init(object initData)
        {
            if (initData != null)
            {
                currentGenreInfo = initData as GenreInfo;

                SetRead();
            }
            else
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
                    Name = GenreName,
                    Description = GenreDescription,
                };

                if (Validate(validateGenre))
                {
                    await genreService.UpdateGenre(validateGenre);
                    await CoreMethods.PopPageModel(validateGenre, false, true);
                }
            });

        public ICommand AddGenreInfoCommand => new Command(
            async () =>
            {
                if (GenreName == null)
                {
                    GenreName = "";
                }
                if (GenreDescription == null)
                {
                    GenreDescription = "";
                }

                GenreInfo genreEdit = new GenreInfo
                {
                    Id = Guid.NewGuid(),
                    Name = GenreName,
                    Description = GenreDescription
                };

                if (Validate(genreEdit))
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
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
            }

            await genreService.DeleteGenre(currentGenreInfo.Id);
            await CoreMethods.PopPageModel(new GenreInfo(), false, true);
        });

        private bool Validate(GenreInfo genreInfo)
        {
            var validationContext = new ValidationContext<GenreInfo>(genreInfo);
            var validationResult = genreInfoValidator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(genreInfo.Name))
                {
                    GenreNameError = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }

        private void SetAdd()
        {
            Title = "New Genre";

            VisableAdd = true;
            VisableCancel = false;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = false;

            EnableGameList = false;
            EnableEditData = true;
        }

        private async void SetRead()
        {
            GenreDescription = currentGenreInfo.Description;
            GenreName = currentGenreInfo.Name;

            Title = currentGenreInfo.Name;

            VisableAdd = false;
            VisableCancel = false;
            VisableEdit = true;
            VisableDelete = true;
            VisableSave = false;

            EnableGameList = true;
            EnableEditData = false;

            var allGames = await gameService.GetAllGames();

            Games = allGames.Where(gamess => gamess.GenreId.Contains(currentGenreInfo.Id)).ToList();

            if(Games.Count()==0)
            {
                EnableGameList = false;
            }
        }

        private void SetEdit()
        {
            Title = "Edit " + currentGenreInfo.Name;

            VisableAdd = false;
            VisableCancel = true;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = true;

            EnableEditData = true;
        }
    }
}