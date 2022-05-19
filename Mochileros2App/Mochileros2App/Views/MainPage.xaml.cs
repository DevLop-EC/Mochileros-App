using Mochileros2App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mochileros2App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void register_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());


        }

        private async void login_Clicked(object sender, EventArgs e)
        {
            // get user and pass
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            // check if user and pass are in the database
            var userExists = await App.Context.LoginUserAsync(email, password);

            if (userExists)
            {
                // login
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                // show error
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }

        }
    }
}
