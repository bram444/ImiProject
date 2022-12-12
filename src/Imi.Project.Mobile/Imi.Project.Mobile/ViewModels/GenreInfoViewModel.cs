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
    public class GenreInfoViewModel: BaseInfoViewModel<GenreInfo>
    {
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
                CurrentItem = initData as GenreInfo;

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
                    Id = CurrentItem.Id,
                    Name = Name,
                    Description = GenreDescription,
                };

                if(Validate(validateGenre))
                {
                    await genreService.Update(validateGenre);
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
                    await genreService.Add(genreEdit);
                    await CoreMethods.PopPageModel(genreEdit, false, true);
                }
            });

        public override ICommand DeleteCommand => new Command(async () =>
        {
            base.DeleteCommand.Execute(null);

            await genreService.Delete(CurrentItem.Id);
            await CoreMethods.PopPageModel(new GenreInfo(), false, true);
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
            Title = "New Genre";

            EnableGameList = false;

            base.SetAdd();
        }

        public override async void SetRead()
        {
            GenreDescription = CurrentItem.Description;
            Name = CurrentItem.Name;

            Title = CurrentItem.Name;

            EnableGameList = true;

            IEnumerable<GamesInfo> allGames = await GameService.GetAll();

            Games = allGames.Where(gamess => gamess.GenreId.Contains(CurrentItem.Id)).ToList();

            if(Games.Count() == 0)
            {
                EnableGameList = false;
            }

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + CurrentItem.Name;

            base.SetEdit();
        }
    }
}