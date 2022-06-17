using Mochileros2App.Data;
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
    public partial class EditPostPage : ContentPage
    {
        readonly Opinions opinions;
        public EditPostPage(Opinions opinionsArg)
        {
            InitializeComponent();
            opinions = opinionsArg;
            opinionEntry.Text = opinions.Opinion;
        }

        private async void UpdateClicked(object sender, EventArgs e)
        {
            opinions.Opinion = opinionEntry.Text;
            await App.Context.UpdateOpinionsAsync(opinions);
            await Navigation.PopAsync();
        }

        private async void DeleteClicked(object sender, EventArgs e)
        {
            await App.Context.DeleteOpinionsAsync(opinions);
            await Navigation.PopAsync();
        }
    }
}