using Mochileros2App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mochileros2App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class OpinionPage : ContentPage
    {
        public List<Opinions> _Opinions = new List<Opinions>();
        public OpinionPage()
        {
            InitializeComponent();

        }





        private async void AddOpinion_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (String.IsNullOrEmpty(opinionEntry.Text))
                {
                    await DisplayAlert("Error", "Ingrese el comentario", "Ok");
                }
                Opinions opinions = new Opinions()
                {
                    Opinion = opinionEntry.Text,
                    Date = DateTime.Now
                };

                var result = await App.Context.InsertOpinionAsync(opinions);

                if (result == 1)
                {
                    await DisplayAlert("EXito", "Comentario registrado", "Ok");

                }
                else
                {
                    await DisplayAlert("Error", "No se pudo registrar la opinion", "Ok");
                }
            }

            catch (Exception err)
            {
                await DisplayAlert("Error", err.Message, "OK");
            }
        }
    }

}






