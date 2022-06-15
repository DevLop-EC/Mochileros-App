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
        Opinions opinions;
        public EditPostPage(Opinions opinionsArg)
        {
            InitializeComponent();
            opinions = opinionsArg;
            opinionEntry.Text = opinions.Opinion;
        }

        private void UpdateClicked(object sender, EventArgs e, Opinions opinions)
        {
          

        }

        private void DeleteClicked(object sender, EventArgs e)
        {

        }
    }
}