using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using KartingExperience.Pages;
using Xamarin.Forms.Xaml;

namespace KartingExperience
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }

        private void Show_AddTrackPage(object sender, EventArgs e)
        {

            App.Current.MainPage = new AddTrack();
            
        }
    }
}
