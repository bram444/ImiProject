using Imi.Project.Mobile.Domain;
using Imi.Project.Mobile.Domain.Entities;
using Imi.Project.Mobile.Domain.Services;
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
    public partial class GenrePage : ContentPage
    {
        private GenreInfoService genreInfo = new GenreInfoService();

        public GenrePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            lvGenreList.ItemsSource = null;
            lvGenreList.ItemsSource = genreInfo.GetAllGenre().Result;

            base.OnAppearing();

        }

        private async void OpenGenre(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new GenreItemPage(e.Item as GenreInfo), true);
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GenreItemPage(), true);
        }
    }
}