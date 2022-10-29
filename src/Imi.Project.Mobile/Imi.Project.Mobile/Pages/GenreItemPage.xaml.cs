using FluentValidation;
using Imi.Project.Mobile.Domain.Entities;
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
    public partial class GenreItemPage : ContentPage
    {
        private readonly Dictionary<string, Label> errorLabels;
        private GenreInfo genreInfo;
        private readonly GenreInfoValidator genreInfoValidator;
        private readonly GenreInfoService genreInfoService;

        public GenreItemPage()
        {
            InitializeComponent();

            errorLabels = new Dictionary<string, Label>
            {
                [nameof(GenreInfo.Name)] = lblNameError,
                [nameof(GenreInfo.Description)] = lblDescriptionError
            };
            HideErrorLabels();

            genreInfoValidator = new GenreInfoValidator();
            genreInfoService = new GenreInfoService();

            btnEdit.IsVisible = false;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;
            btnDelete.IsVisible = false;
        }

        public GenreItemPage(GenreInfo info)
        {
            InitializeComponent();

            genreInfo = info;

            errorLabels = new Dictionary<string, Label>
            {
                [nameof(GenreInfo.Name)] = lblNameError,
                [nameof(GenreInfo.Description)] = lblDescriptionError
            };

            txtName.Text = genreInfo.Name;
            txtDescription.Text = genreInfo.Description;

            txtName.IsEnabled = false;
            txtDescription.IsEnabled = false;

            HideErrorLabels();

            btnEdit.IsVisible = true;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;

            genreInfoValidator = new GenreInfoValidator();
            genreInfoService = new GenreInfoService();
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
            txtDescription.IsEnabled = true;

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

            if (txtDescription.Text == null)
            {
                txtDescription.Text = "";
            }

            GenreInfo genreEdit = new GenreInfo
            {
                Id = genreInfo.Id,
                Name = txtName.Text,
                Description = txtDescription.Text,
            };

            HideErrorLabels();


            var validationContext = new ValidationContext<GenreInfo>(genreEdit);
            var validationResult = genreInfoValidator.Validate(validationContext);

            if (validationResult.IsValid)
            {
                genreInfoService.SaveGenre(genreEdit);
                await Navigation.PopToRootAsync();
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
            if (txtName.Text == null)
            {
                txtName.Text = "";
            }

            if (txtDescription.Text == null)
            {
                txtDescription.Text = "";
            }

            GenreInfo genreEdit = new GenreInfo
            {
                Id = Guid.NewGuid(),
                Name = txtName.Text,
                Description = txtDescription.Text,
            };

            HideErrorLabels();

            var validationContext = new ValidationContext<GenreInfo>(genreEdit);
            var validationResult = genreInfoValidator.Validate(validationContext);

            if (validationResult.IsValid)
            {
                genreInfoService.AddGenre(genreEdit);
                await Navigation.PopToRootAsync();
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
            genreInfoService.RemoveGenre(genreInfo.Id);
            await Navigation.PopToRootAsync();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            txtName.Text = genreInfo.Name;
            txtDescription.Text = genreInfo.Description;

            txtName.IsEnabled = false;
            txtDescription.IsEnabled = false;

            btnEdit.IsVisible = true;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;
            btnDelete.IsVisible = true;

            lblDescriptionError.Text = "";
            lblDescriptionError.IsVisible = false;

            lblNameError.Text = "";
            lblNameError.IsVisible = false;
        }
    }
}