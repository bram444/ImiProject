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
    public class PublisherInfoViewModel: BaseListInfoViewModel<PublisherInfo, IPublisherService, IGameService, NewPublisherInfo, UpdatePublisherInfo>
    {
        public PublisherInfoViewModel(IPublisherService publisherService, IGameService gameService)
            : base(publisherService, gameService, new UpdatePublisherInfoValidator(), new NewPublisherInfoValidator())
        { }

        #region Properties
        private string publisherCountry;
        public string PublisherCountry
        {
            get
            {
                return publisherCountry;
            }

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
            get
            {
                return publisherDeleteError;
            }

            set
            {
                publisherDeleteError = value;
                RaisePropertyChanged(nameof(PublisherDeleteError));
            }
        }

        private string publisherCounryError;
        public string PublisherCountryError
        {
            get
            {
                return publisherCounryError;
            }

            set
            {
                publisherCounryError = value;
                RaisePropertyChanged(nameof(PublisherCountryError));
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

                if(PublisherCountry == null)
                {
                    PublisherCountry = string.Empty;
                }

                NewPublisherInfo publisherEdit = new NewPublisherInfo
                {
                    Name = Name,
                    Country = PublisherCountry,
                };

                ApiResponse<PublisherInfo> apiResponse = await AddItem(publisherEdit);
                ErrorAPI = string.Join(Environment.NewLine, apiResponse.Messages);
            });
            }
        }

        public override ICommand DeleteCommand
        {
            get
            {
                return new Command(() =>
        {
            if(Games.Count() > 0)
            {
                PublisherDeleteError = "Cannot delete while publisher has games";
            } else
            {
                base.DeleteCommand.Execute(null);
            }
        });
            }
        }

        public override ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
            {
                UpdatePublisherInfo validatePublisher = new UpdatePublisherInfo
                {
                    Id = CurrentItem.Id,
                    Country = PublisherCountry,
                    Name = Name
                };
                ApiResponse<PublisherInfo> apiResponse = await SaveItem(validatePublisher);
                ErrorAPI = string.Join(Environment.NewLine, apiResponse.Messages);
            });
            }
        }

        public override bool Validate(NewPublisherInfo publisherInfo)
        {
            ValidationContext<NewPublisherInfo> validationContext = new ValidationContext<NewPublisherInfo>(publisherInfo);
            ValidationResult validationResult = NewValidator.Validate(validationContext);

            foreach(ValidationFailure error in validationResult.Errors)
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

        public override bool Validate(UpdatePublisherInfo publisherInfo)
        {
            ValidationContext<UpdatePublisherInfo> validationContext = new ValidationContext<UpdatePublisherInfo>(publisherInfo);
            ValidationResult validationResult = UpdateValidator.Validate(validationContext);

            foreach(ValidationFailure error in validationResult.Errors)
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

            Games = allGames.Where(gamess => gamess.Publisher.Id == CurrentItem.Id).ToList();

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