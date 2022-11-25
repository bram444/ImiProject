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
    public partial class UserItemPage : ContentPage
    {
        private readonly Dictionary<string, Label> errorLabels;
        private UserInfo userInfo;
        private readonly UserInfoValidator userInfoValidator;
        private readonly UserInfoService userInfoService;

        public UserItemPage()
        {
            InitializeComponent();

            errorLabels = new Dictionary<string, Label>
            {
                [nameof(UserInfo.UserName)] = lblUserNameError,
                [nameof(UserInfo.FirstName)] = lblFirstNameError,
                [nameof(UserInfo.LastName)] = lblLastNameError,
                [nameof(UserInfo.Email)] = lblEmailError
            };
            HideErrorLabels();

            userInfoValidator = new UserInfoValidator();
            userInfoService = new UserInfoService();

            btnEdit.IsVisible = false;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;
            btnDelete.IsVisible = false;
        }

        public UserItemPage(UserInfo info)
        {
            InitializeComponent();

            userInfo = info;

            errorLabels = new Dictionary<string, Label>
            {
                [nameof(UserInfo.UserName)] = lblUserNameError,
                [nameof(UserInfo.FirstName)] = lblFirstNameError,
                [nameof(UserInfo.LastName)] = lblLastNameError,
                [nameof(UserInfo.Email)] = lblEmailError
            };

            txtEmail.Text = userInfo.Email;
            txtFirstName.Text = userInfo.FirstName;
            txtLastName.Text = userInfo.LastName;
            txtUserName.Text = userInfo.UserName;

            txtEmail.IsEnabled = false;
            txtFirstName.IsEnabled = false;
            txtLastName.IsEnabled = false;
            txtUserName.IsEnabled = false;

            HideErrorLabels();

            btnEdit.IsVisible = true;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;

            userInfoValidator = new UserInfoValidator();
            userInfoService = new UserInfoService();
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
            txtEmail.IsEnabled = true;
            txtFirstName.IsEnabled = true;
            txtLastName.IsEnabled = true;
            txtUserName.IsEnabled = true;

            btnEdit.IsVisible = false;
            btnSave.IsVisible = true;
            btnCancel.IsVisible = true;
            btnDelete.IsVisible = false;

        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (txtUserName.Text == null)
            {
                txtUserName.Text = "";
            }

            if (txtFirstName.Text == null)
            {
                txtFirstName.Text = "";
            }

            if (txtLastName.Text == null)
            {
                txtLastName.Text = "";
            }

            if (txtEmail.Text == null)
            {
                txtEmail.Text = "";
            }

            UserInfo userEdit = new UserInfo
            {
                Id = userInfo.Id,
                UserName = txtUserName.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
            };

            HideErrorLabels();

            var validationContext = new ValidationContext<UserInfo>(userEdit);
            var validationResult = userInfoValidator.Validate(validationContext);

            if (validationResult.IsValid)
            {
                userInfoService.SaveUser(userEdit);
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
            if (txtUserName.Text == null)
            {
                txtUserName.Text = "";
            }

            if (txtFirstName.Text == null)
            {
                txtFirstName.Text = "";
            }

            if (txtLastName.Text == null)
            {
                txtLastName.Text = "";
            }

            if (txtEmail.Text == null)
            {
                txtEmail.Text = "";
            }

            UserInfo userEdit = new UserInfo
            {
                Id = Guid.NewGuid(),
                UserName = txtUserName.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
            };

            HideErrorLabels();

            var validationContext = new ValidationContext<UserInfo>(userEdit);
            var validationResult = userInfoValidator.Validate(validationContext);

            if (validationResult.IsValid)
            {
                userInfoService.AddUser(userEdit);
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
            userInfoService.RemoveUser(userInfo.Id);
            await Navigation.PopAsync();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            txtEmail.Text = userInfo.Email;
            txtFirstName.Text = userInfo.FirstName;
            txtLastName.Text = userInfo.LastName;
            txtUserName.Text = userInfo.UserName;

            txtEmail.IsEnabled = false;
            txtFirstName.IsEnabled = false;
            txtLastName.IsEnabled = false;
            txtUserName.IsEnabled = false;

            btnEdit.IsVisible = true;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;
            btnDelete.IsVisible = true;

            lblEmailError.Text = "";
            lblEmailError.IsVisible = false;

            lblFirstNameError.Text = "";
            lblFirstNameError.IsVisible = false;

            lblLastNameError.Text = "";
            lblLastNameError.IsVisible = false;

            lblUserNameError.Text = "";
            lblUserNameError.IsVisible = false;
        }
    }
}