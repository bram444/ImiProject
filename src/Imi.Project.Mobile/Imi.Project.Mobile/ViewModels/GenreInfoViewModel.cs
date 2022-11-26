using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GenreInfoViewModel : FreshBasePageModel
    {
        private GenreInfo currentGenreInfo;
        private readonly IValidator genreInfoValidator;

        private readonly IGenreService genreService;

        public GenreInfoViewModel(IGenreService genreService)
        {
            this.genreService = genreService;

            genreInfoValidator = new GenreInfoValidator();
        }

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

        public override void Init(object initData)
        {
            if (initData != null)
            {
                currentGenreInfo = initData as GenreInfo;

                Title = currentGenreInfo.Name;
                LoadGenreState();
                SetRead();

            }
            else
            {
                Title = "New Genre";
                SetAdd();
            }

            base.Init(initData);
        }

        private void LoadGenreState()
        {
            GenreDescription = null;
            GenreName = null;

            GenreDescription = currentGenreInfo.Description;
            GenreName = currentGenreInfo.Name;
        }

        private void SaveGenreState()
        {
            currentGenreInfo.Description = GenreDescription;
            currentGenreInfo.Name = GenreName;
        }

        public ICommand SaveGenreInfoCommand => new Command(
                async () =>
                {
                    SaveGenreState();

            if (Validate(currentGenreInfo))
            {
                await genreService.UpdateGenre(currentGenreInfo);
                await CoreMethods.PopPageModel(currentGenreInfo, false, true);
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
            LoadGenreState();
            SetRead();
        });

        public ICommand DeleteCommand => new Command(async () =>
        {
            await genreService.DeleteGenre(currentGenreInfo.Id);
            await CoreMethods.PopPageModel(new GenreInfo(),false,true);
        });

        private bool Validate(GenreInfo genreInfo)
        {
            var validationContext = new ValidationContext<GenreInfo>(genreInfo);
            var validationResult = genreInfoValidator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                if(error.PropertyName == nameof(genreInfo.Name))
                    {
                    GenreNameError = error.ErrorMessage;

                }
            }
            return validationResult.IsValid;
        }

        private void SetAdd()
        {
            VisableAdd = true;
            VisableCancel = false;

            EnableEditData = true;

            VisableEdit = false;
            VisableDelete = false;
            VisableSave = false;
        }

        private void SetRead()
        {
            Title = currentGenreInfo.Name;
            VisableAdd = false;
            VisableCancel = false;

            EnableEditData = false;

            VisableEdit = true;
            VisableDelete = true;
            VisableSave = false;
        }

        private void SetEdit()
        {
            Title = "Edit " + currentGenreInfo.Name;

            VisableAdd = false;
            VisableCancel = true;

            EnableEditData = true;

            VisableEdit = false;
            VisableDelete = false;
            VisableSave = true;
        }

    }
}
