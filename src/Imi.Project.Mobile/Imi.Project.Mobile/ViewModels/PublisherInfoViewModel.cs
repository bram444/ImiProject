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
    public class PublisherInfoViewModel: BaseListInfoViewModel<PublisherInfo,IPublisherService,IGameService>
    {
        public PublisherInfoViewModel(IPublisherService publisherService, IGameService gameService)
            : base(publisherService, gameService, new PublisherInfoValidator())
        { }

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
        #endregion

        public override ICommand AddCommand => new Command(() =>
            {
                base.AddCommand.Execute(null);

                if(PublisherCountry == null)
                {
                    PublisherCountry = string.Empty;
                }

                PublisherInfo publisherEdit = new PublisherInfo
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    Country = PublisherCountry,
                };

                AddItem(publisherEdit);
            });

        public override ICommand DeleteCommand => new Command(() =>
        {
            if(Games.Count() > 0)
            {
                PublisherDeleteError = "Cannot delete while publisher has games";
            } else
            {
                base.DeleteCommand.Execute(null);
            }
        });

        public override ICommand SaveCommand => new Command(() =>
            {
                PublisherInfo validatePublisher = new PublisherInfo
                {
                    Id = CurrentItem.Id,
                    Country = PublisherCountry,
                    Name = Name
                };

                SaveItem(validatePublisher);
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

            IEnumerable<GamesInfo> allGames = await ListService.GetAll();

            Games = allGames.Where(gamess => gamess.PublisherId == CurrentItem.Id).ToList();

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