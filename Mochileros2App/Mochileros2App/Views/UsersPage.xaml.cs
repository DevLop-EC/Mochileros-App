using Mochileros2App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mochileros2App.Helpers;

namespace Mochileros2App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            UsersListView.ItemsSource = await GetApiUsers();
        }

        private async Task<List<Users>> GetApiUsers()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(Constants.URL_USERS),
                Method = HttpMethod.Get
            };
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Users>>(content);
               
                return resultado;
            }
            else
            {
                await DisplayAlert("Error", "Error al conectar con el servidor", "Aceptar");
                return null;
            }
        }

        private void UsersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}