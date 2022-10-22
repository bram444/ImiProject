using Imi.Project.Api.WPF.ApiResponseModule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Imi.Project.Api.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;

        public MainWindow(IHttpClientFactory httpClientFactory)
        {
            InitializeComponent();
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private async void Reset()
        {
            tbxName.IsEnabled = false;
            tbxDescription.IsEnabled = false;
            txbSucces.IsEnabled = false;

            btnCreate.IsEnabled = false;
            btnRemove.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnCancel.IsEnabled = false;

            btnGet.IsEnabled = true;
            btnPost.IsEnabled = true;
            btnPut.IsEnabled = true;
            btnDelete.IsEnabled = true;

            tbxName.Text = "";
            tbxDescription.Text = "";

            var responseRoles = await _httpClient.GetAsync("Api/Genre");

            if (responseRoles.IsSuccessStatusCode)
            {
                var genres = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<GenreApiResponse>>(await responseRoles.Content.ReadAsStreamAsync());

                FillListBox(genres);
            }
            else
            {
                txbSucces.Text = "Problem with Roles";
            }
        }

        public void FillListBox(IEnumerable<GenreApiResponse> genres)
        {
            lstGenre.Items.Clear();

            foreach (var genre in genres)
            {
                lstGenre.Items.Add(genre);
            }
        }

        public async void FillGenreList()
        {
            lstGenre.Items.Clear();
            var responseGenre = await _httpClient.GetAsync("Api/Genre");
            if (responseGenre.IsSuccessStatusCode)
            {
                using var responseStreamGenre = await responseGenre.Content.ReadAsStreamAsync();
                var genres = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<GenreApiResponse>>(responseStreamGenre);

                foreach (var genre in genres)
                {
                    lstGenre.Items.Add(genre);
                }
            }
            else
            {
                txbSucces.Text = "Problem reloading Users";
            }
        }

        private async void Create_Genre(object sender, RoutedEventArgs e)
        {
            if (tbxName.Text != null)
            {

                var payload = new GenreApiResponse()
                {
                    Id = Guid.NewGuid(),
                    Description = tbxDescription.Text,
                    Name = tbxName.Text
                };

                var contentGenre = JsonConvert.SerializeObject(payload);

                var httpContentGenre = new StringContent(contentGenre, Encoding.UTF8, "application/json");

                var responseGenre = await _httpClient.PostAsync("Api/Genre", httpContentGenre);

                if (responseGenre.IsSuccessStatusCode)
                {
                    txbSucces.Text = "Genre added";
                    Reset();

                }
                else
                {
                    txbSucces.Text = "Failed to add Genre";
                }
            }
            else
            {
                txbSucces.Text = "Please fill in genre name";
            }
        }
        private void Begin_Delete(object sender, RoutedEventArgs e)
        {
            Reset();
            btnGet.IsEnabled = false;
            btnPost.IsEnabled = false;
            btnPut.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnCancel.IsEnabled = true;
            lstGenre.IsEnabled = true;
            btnRemove.IsEnabled = true;
        }

        private void Begin_Post(object sender, RoutedEventArgs e)
        {
            Reset();
            btnGet.IsEnabled = false;
            btnPost.IsEnabled = false;
            btnPut.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnCancel.IsEnabled = true;
            lstGenre.IsEnabled = true;
            btnRemove.IsEnabled = false;
            btnCreate.IsEnabled = true;

            tbxName.IsEnabled = true;
            tbxDescription.IsEnabled = true;
        }

        private void Begin_Get(object sender, RoutedEventArgs e)
        {
            Reset();
            btnGet.IsEnabled = false;
            btnPost.IsEnabled = false;
            btnPut.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnCancel.IsEnabled = true;
            lstGenre.IsEnabled = true;
            btnRemove.IsEnabled = false;
        }

        private void Begin_Put(object sender, RoutedEventArgs e)
        {
            Reset();
            btnGet.IsEnabled = false;
            btnPost.IsEnabled = false;
            btnPut.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnCancel.IsEnabled = true;
            btnRemove.IsEnabled = false;
            btnUpdate.IsEnabled = true;

            tbxName.IsEnabled = true;
            tbxDescription.IsEnabled = true;
            lstGenre.IsEnabled = true;
        }

        private async void  Remove_Genre(object sender, RoutedEventArgs e)
        {
            var genre = (GenreApiResponse)lstGenre.SelectedItem;

            var httpResponse = await _httpClient.DeleteAsync($"Api/genre/{genre.Id}");

            if (httpResponse.IsSuccessStatusCode)
            {
                txbSucces.Text = "Succesfully removed";
            }
            else
            {
                txbSucces.Text = "Error while removing";
            }
            lstGenre.SelectedItem = null;
            FillGenreList();
        }

        private async void Update_Genre(object sender, RoutedEventArgs e)
        {

            var genre = (GenreApiResponse)lstGenre.SelectedItem;

            if (genre != null)
            {
                var payload = new GenreApiResponse
                {
                    Id = genre.Id,
                    Description = tbxDescription.Text,
                    Name = tbxName.Text,
                };


                var contentGenre = JsonConvert.SerializeObject(payload);

                var httpContentGenre = new StringContent(contentGenre, Encoding.UTF8, "application/json");

                var responseGenre = await _httpClient.PutAsync("Api/genre", httpContentGenre);

                if (responseGenre.IsSuccessStatusCode)
                {
                    Reset();
                    txbSucces.Text = "Updated genre";

                }
                else
                {
                    txbSucces.Text = "Failed to updated genre";
                }

            }
            else
            {
                txbSucces.Text = "Select a genre";
            }
        }


        private void Cancel_Genre(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Genre_Select(object sender, SelectionChangedEventArgs e)
        {
            var genre = (GenreApiResponse)lstGenre.SelectedItem;
            if (genre != null)
            {
                tbxName.Text = genre.Name;
                tbxDescription.Text=genre.Description;
            }
        }
    }
}
