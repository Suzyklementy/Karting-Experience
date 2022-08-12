using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KartingExperience.Models;

namespace KartingExperience.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackDetailsPage : ContentPage
    {
        public TrackDetailsPage()
        {
            InitializeComponent();

            BindingContext = new TrackDetailsPageViewModel();
        }

        private void Back(object sender, EventArgs e)
        {

            App.Current.MainPage = new MainPage();

        }
    }
}