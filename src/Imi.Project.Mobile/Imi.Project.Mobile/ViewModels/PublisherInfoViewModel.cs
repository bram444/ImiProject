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
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class PublisherInfoViewModel : FreshBasePageModel
    {
        private PublisherInfo currentPublisherInfo;
        private readonly IValidator publisherInfoValidator;

        private readonly IPublisherService publisherService;

        public PublisherInfoViewModel(IPublisherService publisherService)
        {
            this.publisherService = publisherService;

            publisherInfoValidator = new PublisherInfoValidator();
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

        public override void Init(object initData)
        {
            if (initData != null)
            {
                currentPublisherInfo = initData as PublisherInfo;

                Title = currentPublisherInfo.Name;
                LoadPublisherState();
                SetRead();

            }
            else
            {
                Title = "New publisher";
                SetAdd();
            }

            base.Init(initData);
        }

        private void LoadPublisherState()
        {
            PublisherCountry = null;
            PublisherName = null;

            PublisherCountry = currentPublisherInfo.Country;
            PublisherName = currentPublisherInfo.Name;
        }

        private void SavePublisherState()
        {
            currentPublisherInfo.Country = PublisherCountry;
            currentPublisherInfo.Name = PublisherName;
        }

        public ICommand SavePublisherInfoCommand => new Command(
                async () =>
                {
                    SavePublisherState();

                    if (Validate(currentPublisherInfo))
                    {
                        await publisherService.UpdatePublisher(currentPublisherInfo);
                        await CoreMethods.PopPageModel(currentPublisherInfo, false, true);
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
            LoadPublisherState();
            SetRead();
        });

        public ICommand DeleteCommand => new Command(async () =>
        {
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
            }

            await publisherService.DeletePublisher(currentPublisherInfo.Id);
            await CoreMethods.PopPageModel(new PublisherInfo(),false,true);
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
            VisableAdd = true;
            VisableCancel = false;

            EnableEditData = true;

            VisableEdit = false;
            VisableDelete = false;
            VisableSave = false;
        }

        private void SetRead()
        {
            Title = currentPublisherInfo.Name;
            VisableAdd = false;
            VisableCancel = false;

            EnableEditData = false;

            VisableEdit = true;
            VisableDelete = true;
            VisableSave = false;
        }

        private void SetEdit()
        {
            Title = "Edit " + currentPublisherInfo.Name;

            VisableAdd = false;
            VisableCancel = true;

            EnableEditData = true;

            VisableEdit = false;
            VisableDelete = false;
            VisableSave = true;
        }

    }
}
