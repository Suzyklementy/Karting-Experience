using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KartingExperience.Database;
using KartingExperience.Models;

namespace KartingExperience
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var database = new KartExpDbContext();
            database.Database.EnsureCreated();
            TrackListHandler.Database = database;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {

            TrackListHandler.GetData();

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
