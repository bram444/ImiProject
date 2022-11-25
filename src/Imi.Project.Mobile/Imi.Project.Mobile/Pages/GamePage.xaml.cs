using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Imi.Project.Mobile;
using System.Windows.Input;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        private GameInfoService gameInfo = new GameInfoService();

        public GamePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            lvGameList.ItemsSource = null;
            lvGameList.ItemsSource = gameInfo.GetAllGames().Result;
            base.OnAppearing();

        }

        private async void OpenGame(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new GameItemPage(e.Item as GamesInfo), true);
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GameItemPage(), true);
        }
    }
}