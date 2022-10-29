﻿using Imi.Project.Mobile.Domain;
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
            base.OnAppearing();

            lvGenreList.ItemsSource = genreInfo.GetAllGenre().Result;
        }
    }
}