using FluentValidation;
using FluentValidation.Results;
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
    public partial class GameItemPage : ContentPage
    {
        private readonly Dictionary<string, Label> errorLabels;
        private GamesInfo gamesInfo;
        private readonly GameInfoValidator gameInfoValidator;
        private readonly GameInfoService gameInfoService;
        public GameItemPage()
        {
            InitializeComponent();

            errorLabels = new Dictionary<string, Label>
            {
                [nameof(GamesInfo.Name)] = lblNameError,
                [nameof(GamesInfo.Price)] = lblPriceError
            };
            HideErrorLabels();

            gameInfoValidator = new GameInfoValidator();
            gameInfoService= new GameInfoService();

            btnEdit.IsVisible = false;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;
            btnDelete.IsVisible = false;
        }

        public GameItemPage(GamesInfo info)
        {
            InitializeComponent();
            gamesInfo = info;

            errorLabels = new Dictionary<string, Label>
            {
                [nameof(GamesInfo.Name)] = lblNameError,
                [nameof(GamesInfo.Price)] = lblPriceError
            };

            txtName.Text= gamesInfo.Name;
            txtPrice.Text = gamesInfo.Price.ToString();

            txtName.IsEnabled = false;
            txtPrice.IsEnabled = false;

            HideErrorLabels();

            btnEdit.IsVisible=true;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;

            gameInfoValidator = new GameInfoValidator();
            gameInfoService = new GameInfoService();
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
            txtPrice.IsEnabled = true;

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

            GamesInfo gameEdit = new GamesInfo
            {
                Id = gamesInfo.Id,
                Name = txtName.Text,
                Price = 0.0f
            };

            HideErrorLabels();

            var validationContext = new ValidationContext<GamesInfo>(gameEdit);
            var validationResult = gameInfoValidator.Validate(validationContext);

            float isfloat;

            if (txtPrice.Text == null || txtPrice.Text == "")
            {
                txtPrice.Text = "0";
            }
            if (float.TryParse(txtPrice.Text, out isfloat))
            {
                gameEdit.Price = float.Parse(txtPrice.Text);
                if (validationResult.IsValid)
                {
                    gameInfoService.SaveGames(gameEdit);
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
            else
            {
                lblPriceError.Text = "Give a valid number";
                lblPriceError.IsVisible = true;

            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if (txtName.Text == null)
            {
                txtName.Text = "";
            }

            GamesInfo gameEdit = new GamesInfo
            {
                Id = Guid.NewGuid(),
                Name = txtName.Text,
                Price = 0.0f
            };

            HideErrorLabels();

            var validationContext = new ValidationContext<GamesInfo>(gameEdit);
            var validationResult = gameInfoValidator.Validate(validationContext);

            float isfloat;
            if(txtPrice.Text == null || txtPrice.Text == "")
            {
                txtPrice.Text = "0";
            }
            if (float.TryParse(txtPrice.Text, out isfloat))
            {
                gameEdit.Price = float.Parse(txtPrice.Text);
                if (validationResult.IsValid)
                {
                    gameInfoService.AddGames(gameEdit);
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
            else
            {
                lblPriceError.Text = "Give a valid number";
                lblPriceError.IsVisible = true;

            }
        }


        private async void Delete_Clicked(object sender, EventArgs e)
        {
            gameInfoService.RemoveGames(gamesInfo.Id);
            await Navigation.PopToRootAsync();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            txtName.Text = gamesInfo.Name;
            txtPrice.Text = gamesInfo.Price.ToString();

            txtName.IsEnabled = false;
            txtPrice.IsEnabled = false;

            btnEdit.IsVisible = true;
            btnSave.IsVisible = false;
            btnCancel.IsVisible = false;
            btnDelete.IsVisible = true;

            lblPriceError.Text = "";
            lblPriceError.IsVisible = false;

            lblNameError.Text = "";
            lblNameError.IsVisible = false;
        }
    }
}