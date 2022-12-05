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
    public class PublisherInfoViewModel : FreshBasePageModel
    {
        private PublisherInfo currentPublisherInfo;
        private readonly IValidator publisherInfoValidator;
        private readonly IPublisherService publisherService;
        private readonly IGameService gameService;

        public PublisherInfoViewModel(IPublisherService publisherService, IGameService gameService)
        {
            this.publisherService = publisherService;
            this.gameService = gameService;

            publisherInfoValidator = new PublisherInfoValidator();
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

        private string publisherName;
        public string PublisherName
        {
            get { return publisherName; }
            set
            {
                publisherName = value;
                PublisherNameError = null;
                RaisePropertyChanged(nameof(PublisherName));
            }
        }

        private string publisherCountry;
        public string PublisherCountry
        {
            get { return publisherCountry; }
            set
            {
                publisherCountry = value;
                PublisherCountryError = null;
                RaisePropertyChanged(nameof(PublisherCountry));
            }
        }

        private string publisherNameError;
        public string PublisherNameError
        {
            get { return publisherNameError; }
            set
            {
                publisherNameError = value;
                RaisePropertyChanged(nameof(PublisherNameError));
                RaisePropertyChanged(nameof(PublisherNameErrorVisible));
            }
        }

        public bool PublisherNameErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(PublisherNameError); }
        }

        private string publisherDeleteError;
        public string PublisherDeleteError
        {
            get { return publisherDeleteError; }
            set
            {
                publisherDeleteError = value;
                RaisePropertyChanged(nameof(PublisherDeleteError));
                RaisePropertyChanged(nameof(PublisherDeleteErrorVisible));
            }
        }

        public bool PublisherDeleteErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(PublisherDeleteError); }
        }

        private string publisherCounryError;
        public string PublisherCountryError
        {
            get { return publisherCounryError; }
            set
            {
                publisherCounryError = value;
                RaisePropertyChanged(nameof(PublisherCountryError));
                RaisePropertyChanged(nameof(PublisherCounryErrorVisible));
            }
        }

        public bool PublisherCounryErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(PublisherCountryError); }
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

        #endregion

        public override void Init(object initData)
        {
            if (initData != null)
            {
                currentPublisherInfo = initData as PublisherInfo;

                SetRead();
            }
            else
            {
                SetAdd();
            }

            base.Init(initData);
        }

        public ICommand SavePublisherInfoCommand => new Command(
            async () =>
            {
                var validatePublisher = new PublisherInfo
                {
                    Id = currentPublisherInfo.Id,
                    Country = PublisherCountry,
                    Name = PublisherName
                };

                if (Validate(validatePublisher))
                {
                    await publisherService.UpdatePublisher(validatePublisher);
                    await CoreMethods.PopPageModel(validatePublisher, false, true);
                }
            });

        public ICommand AddPublisherInfoCommand => new Command(
            async () =>
            {
                if (PublisherName == null)
                {
                    PublisherName = "";
                }

                if (PublisherCountry == null)
                {
                    PublisherCountry = "";
                }

                PublisherInfo publisherEdit = new PublisherInfo
                {
                    Id = Guid.NewGuid(),
                    Name = PublisherName,
                    Country = PublisherCountry,
                };

                if (Validate(publisherEdit))
                {
                    await publisherService.AddPublisher(publisherEdit);
                    await CoreMethods.PopPageModel(publisherEdit, false, true);
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
            if (Games.Count() > 0)
            {
                PublisherDeleteError = "Cannot delete while publisher has games";
            }
            else
            {
                if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
                }

                await publisherService.DeletePublisher(currentPublisherInfo.Id);
                await CoreMethods.PopPageModel(new PublisherInfo(), false, true);
            }
        });

        private bool Validate(PublisherInfo publisherInfo)
        {
            var validationContext = new ValidationContext<PublisherInfo>(publisherInfo);
            var validationResult = publisherInfoValidator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                switch (error.PropertyName)
                {
                    case nameof(publisherInfo.Name):
                        PublisherNameError = error.ErrorMessage;
                        break;

                    case nameof(publisherInfo.Country):
                        PublisherCountryError = error.ErrorMessage;
                        break;

                    default:
                        PublisherCountryError = "";
                        PublisherNameError = "";
                        break;
                }
            }
            return validationResult.IsValid;
        }

        private void SetAdd()
        {
            Title = "New publisher";

            VisableAdd = true;
            VisableCancel = false;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = false;

            EnableEditData = true;
        }

        private async void SetRead()
        {
            Title = currentPublisherInfo.Name;
            PublisherCountry = currentPublisherInfo.Country;
            PublisherName = currentPublisherInfo.Name;

            VisableAdd = false;
            VisableCancel = false;
            VisableEdit = true;
            VisableDelete = true;
            VisableSave = false;

            EnableGameList = true;
            EnableEditData = false;

            var allGames = await gameService.GetAllGames();

            Games = allGames.Where(gamess => gamess.PublisherId == currentPublisherInfo.Id).ToList();

            if (Games.Count() == 0)
            {
                EnableGameList = false;
            }
        }

        private void SetEdit()
        {
            Title = "Edit " + currentPublisherInfo.Name;

            VisableAdd = false;
            VisableCancel = true;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = true;

            EnableEditData = true;

            PublisherDeleteError = null;
        }
    }
}