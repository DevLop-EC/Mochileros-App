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

        private async void Button_Clicked(object sender, EventArgs e)
        {

            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Advertencia", "Debe introducir el correo y contraseña", "Ok");
            }
            else if (email == "clopez@gmail.com" && password == "1234")
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Advertencia", "Correo o contraseña incorrectos", "Ok");
            }




        }
    }
}
