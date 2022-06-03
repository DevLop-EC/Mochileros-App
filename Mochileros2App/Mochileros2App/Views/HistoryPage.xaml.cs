﻿using Mochileros2App.Data;
using Mochileros2App.Models;
using SQLite;
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


    public partial class HistoryPage : ContentPage
    {

        public List<Opinions> Opinions { get; private set; }


        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadOpinions();
        }

        public async void LoadOpinions()
        {
            var opinions = await App.Context.GetOpinionsAsync();
            opinionListView.ItemsSource = opinions;
        }

    }


}
