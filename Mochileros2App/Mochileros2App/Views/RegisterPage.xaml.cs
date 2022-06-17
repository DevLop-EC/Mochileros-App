using Mochileros2App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mochileros2App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public async void LoginRedirect_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void RegisterSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var newUser = new Auth
                {
                    Name = nameEntry.Text,
                    LastName = lastNameEntry.Text,
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text,
                    Phone = phoneEntry.Text,

                };

                var result = await App.Context.RegisterUserAsync(newUser);
                if (result == 1)
                {
                    await DisplayAlert("Registro", "Usuario registrado correctamente", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Error al registrar usuario", "OK");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}