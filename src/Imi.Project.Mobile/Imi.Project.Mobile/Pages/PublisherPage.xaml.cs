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
    public partial class PublisherPage : ContentPage
    {
        private PublisherInfoService publisherInfo = new PublisherInfoService();


        public PublisherPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lvPublisherList.ItemsSource = publisherInfo.GetAllPublisher().Result;
        }

        private async void OpenPublisher(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new PublisherItemPage(e.Item as PublisherInfo), true);
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PublisherItemPage(), true);
        }
    }
}