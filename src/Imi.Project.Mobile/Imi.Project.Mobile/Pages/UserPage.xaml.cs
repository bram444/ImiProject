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
    public partial class UserPage : ContentPage
    {
        private UserInfoService userInfo = new UserInfoService();

        public UserPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lvUserList.ItemsSource = userInfo.GetAllUser().Result;
        }

        private async void OpenUser(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new UserItemPage(e.Item as UserInfo), true);
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserItemPage(), true);
        }
    }
}