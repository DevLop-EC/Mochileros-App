using Mochileros2App.Helpers;
using Mochileros2App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mochileros2App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPostList : ContentPage
    {

        public UserApiPost user;

        public UserPostList(UserApiPost userPost)
        {

            InitializeComponent();
            user = userPost;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            userPostListView.ItemsSource = await GetUsersPosts();
        }

        private async Task<List<UserApiPost>> GetUsersPosts()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(Constants.URL_POSTS),
                Method = HttpMethod.Get
            };
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(String.Format(Constants.URL_POSTS, user.id));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<UserApiPost>>(content);

                return posts;
            }
            else
            {
                await DisplayAlert("Error", "Error al conectar con el servidor", "Aceptar");
                return null;
            }
        }

        private void userPostListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            UserApiPost user = (UserApiPost)e.SelectedItem;
            Navigation.PushAsync(new UserPostList(user));
        }
    }
}