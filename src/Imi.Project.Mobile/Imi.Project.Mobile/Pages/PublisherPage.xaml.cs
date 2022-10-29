using Imi.Project.Mobile.Domain;
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

        
    }
}