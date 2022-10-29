using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGame_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GamePage(), true);
        }

        private async void btnGenre_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GenrePage(), true);
        }

        private async void btnPublisher_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PublisherPage(), true);
        }

        private async void btnUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPage(), true);
        }
    }
}
