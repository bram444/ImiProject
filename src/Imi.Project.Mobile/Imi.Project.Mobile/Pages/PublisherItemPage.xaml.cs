using FluentValidation;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublisherItemPage : ContentPage
    {
        private readonly Dictionary<string, Label> errorLabels;
        private PublisherInfo publisherInfo;
        private readonly PublisherInfoValidator publisherInfoValidator;
        private readonly PublisherInfoService publisherInfoService;

        public PublisherItemPage()
        {
            InitializeComponent();

            errorLabels = new Dictionary<string, Label>
            {
                [nameof(PublisherInfo.Name)] = lblNameError,
                [nameof(PublisherInfo.Country)] = lblCountryError
            };
            HideErrorLabels();

            publisherInfoValidator = new PublisherInfoValidator();
            publisherInfoService = new PublisherInfoService();

            btnEdit.IsVisible = false;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;
            btnDelete.IsVisible = false;
        }

        public PublisherItemPage(PublisherInfo info)
        {
            InitializeComponent();

            publisherInfo = info;

            errorLabels = new Dictionary<string, Label>
            {
                [nameof(PublisherInfo.Name)] = lblNameError,
                [nameof(PublisherInfo.Country)] = lblCountryError
            };

            txtName.Text = publisherInfo.Name;
            txtCountry.Text = publisherInfo.Country;

            txtName.IsEnabled = false;
            txtCountry.IsEnabled = false;

            HideErrorLabels();

            btnEdit.IsVisible = true;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;

            publisherInfoValidator = new PublisherInfoValidator();
            publisherInfoService = new PublisherInfoService();
            btnAdd.IsVisible = false;
        }

        private void HideErrorLabels()
        {
            foreach (var errorLabel in errorLabels.Values)
            {
                errorLabel.Text = null;
                errorLabel.IsVisible = false;
            }
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            txtName.IsEnabled = true;
            txtCountry.IsEnabled = true;

            btnEdit.IsVisible = false;
            btnSave.IsVisible = true;
            btnCancel.IsVisible = true;
            btnDelete.IsVisible = false;

        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (txtName.Text == null)
            {
                txtName.Text = "";
            }

            if (txtCountry.Text == null)
            {
                txtCountry.Text = "";
            }

            PublisherInfo publisherEdit = new PublisherInfo
            {
                Id = publisherInfo.Id,
                Name = txtName.Text,
                Country = txtCountry.Text,
            };

            HideErrorLabels();

            var validationContext = new ValidationContext<PublisherInfo>(publisherEdit);
            var validationResult = publisherInfoValidator.Validate(validationContext);

            if (validationResult.IsValid)
            {
                publisherInfoService.SavePublisher(publisherEdit);
                await Navigation.PopAsync();
            }
            else
            {
                foreach (var validationError in validationResult.Errors)
                {
                    var errorLabel = errorLabels[validationError.PropertyName];
                    errorLabel.Text = validationError.ErrorMessage;
                    errorLabel.IsVisible = true;
                }
            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if (txtCountry.Text == null)
            {
                txtCountry.Text = "";
            }

            PublisherInfo publisherEdit = new PublisherInfo
            {
                Id = Guid.NewGuid(),
                Name = txtName.Text,
                Country = txtCountry.Text,
            };

            HideErrorLabels();

            var validationContext = new ValidationContext<PublisherInfo>(publisherEdit);
            var validationResult = publisherInfoValidator.Validate(validationContext);

            if (validationResult.IsValid)
            {
                publisherInfoService.AddPublisher(publisherEdit);
                await Navigation.PopAsync();
            }
            else
            {
                foreach (var validationError in validationResult.Errors)
                {
                    var errorLabel = errorLabels[validationError.PropertyName];
                    errorLabel.Text = validationError.ErrorMessage;
                    errorLabel.IsVisible = true;
                }
            }
        }


        private async void Delete_Clicked(object sender, EventArgs e)
        {
            publisherInfoService.RemovePublisher(publisherInfo.Id);
            await Navigation.PopAsync();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            txtName.Text = publisherInfo.Name;
            txtCountry.Text = publisherInfo.Country;

            txtName.IsEnabled = false;
            txtCountry.IsEnabled = false;

            btnEdit.IsVisible = true;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;
            btnDelete.IsVisible = true;

            lblCountryError.Text = "";
            lblCountryError.IsVisible = false;

            lblNameError.Text = "";
            lblNameError.IsVisible = false;
        }
    }
}