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
    public class PublisherInfoViewModel: BaseInfoViewModel<PublisherInfo>
    {
        private readonly IPublisherService publisherService;

        public PublisherInfoViewModel(IPublisherService publisherService, IGameService gameService):base(gameService)
        {
            this.publisherService = publisherService;

            InfoValidator = new PublisherInfoValidator();
        }

        #region Properties

        private string publisherCountry;
        public string PublisherCountry
        {
            get => publisherCountry;
            set
            {
                publisherCountry = value;
                PublisherCountryError = null;
                RaisePropertyChanged(nameof(PublisherCountry));
            }
        }

        private string publisherDeleteError;
        public string PublisherDeleteError
        {
            get => publisherDeleteError;
            set
            {
                publisherDeleteError = value;
                RaisePropertyChanged(nameof(PublisherDeleteError));
            }
        }

        private string publisherCounryError;
        public string PublisherCountryError
        {
            get => publisherCounryError;
            set
            {
                publisherCounryError = value;
                RaisePropertyChanged(nameof(PublisherCountryError));
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

        #endregion

        public override void Init(object initData)
        {
            if(initData != null)
            {
                CurrentItem = initData as PublisherInfo;

                SetRead();
            } else
            {
                SetAdd();
            }

            base.Init(initData);
        }

        public ICommand SavePublisherInfoCommand => new Command(
            async () =>
            {
                PublisherInfo validatePublisher = new PublisherInfo
                {
                    Id = CurrentItem.Id,
                    Country = PublisherCountry,
                    Name = this.Name
                };

                if(Validate(validatePublisher))
                {
                    await publisherService.Update(validatePublisher);
                    await CoreMethods.PopPageModel(validatePublisher, false, true);
                }
            });

        public ICommand AddPublisherInfoCommand => new Command(
            async () =>
            {
                if(Name == null)
                {
                    Name = "";
                }

                if(PublisherCountry == null)
                {
                    PublisherCountry = "";
                }

                PublisherInfo publisherEdit = new PublisherInfo
                {
                    Id = Guid.NewGuid(),
                    Name = this.Name,
                    Country = PublisherCountry,
                };

                if(Validate(publisherEdit))
                {
                    await publisherService.Add(publisherEdit);
                    await CoreMethods.PopPageModel(publisherEdit, false, true);
                }
            });

        public override ICommand DeleteCommand => new Command(async () =>
        {
            if(Games.Count() > 0)
            {
                PublisherDeleteError = "Cannot delete while publisher has games";
            } else
            {

                base.DeleteCommand.Execute(null);

                await publisherService.Delete(CurrentItem.Id);
                await CoreMethods.PopPageModel(new PublisherInfo(), false, true);
            }
        });

        public override bool Validate(PublisherInfo publisherInfo)
        {
            ValidationContext<PublisherInfo> validationContext = new ValidationContext<PublisherInfo>(publisherInfo);
            FluentValidation.Results.ValidationResult validationResult = InfoValidator.Validate(validationContext);

            foreach(FluentValidation.Results.ValidationFailure error in validationResult.Errors)
            {
                switch(error.PropertyName)
                {
                    case nameof(publisherInfo.Name):
                        NameError = error.ErrorMessage;
                        break;

                    case nameof(publisherInfo.Country):
                        PublisherCountryError = error.ErrorMessage;
                        break;

                    default:
                        PublisherCountryError = "Unknown error";
                        NameError = "Unknown error";
                        break;
                }
            }

            return validationResult.IsValid;
        }

        public override void SetAdd()
        {
            Title = "New publisher";

            base.SetAdd();
        }

        public override async void SetRead()
        {
            Title = CurrentItem.Name;
            PublisherCountry = CurrentItem.Country;
            Name = CurrentItem.Name;

            EnableGameList = true;

            IEnumerable<GamesInfo> allGames = await GameService.GetAll();

            Games = allGames.Where(gamess => gamess.PublisherId == CurrentItem.Id).ToList();

            if(Games.Count() == 0)
            {
                EnableGameList = false;
            }

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + CurrentItem.Name;

            PublisherDeleteError = null;

            base.SetEdit();
        }
    }
}