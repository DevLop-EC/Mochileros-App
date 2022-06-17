using Mochileros2App.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mochileros2App
{
    public partial class App : Application

    {

        public static DatabaseContext Context { get; set; }

        public App()
        {
            InitializeComponent();
            InitialDatabase();
            MainPage = new NavigationPage(new MainPage());

        }

        private void InitialDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folderApp, "Mochileros2.sqlite");
            Context = new DatabaseContext(dbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
