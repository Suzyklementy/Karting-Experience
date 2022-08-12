﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KartingExperience.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTrack : ContentPage
    {
        public AddTrack()
        {
            InitializeComponent();

            BindingContext = new AddTrackPageViewModel();
        }

        private void LeavePage(object sender, EventArgs e)
        {

            App.Current.MainPage = new MainPage();

        }
    }
}