using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KartingExperience.Pages;

namespace KartingExperience.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Track : ViewCell
    {
        public Track()
        {
            InitializeComponent();
        }

        private void ShowTrackDetails(object sender, EventArgs e)
        {

            int id = (int)((Button)sender).CommandParameter;
            TrackDetailsPageViewModel.Id = id;

            //Console.WriteLine(TrackDetailsPageViewModel.Id);

            App.Current.MainPage = new TrackDetailsPage();
    
        }
    }
}