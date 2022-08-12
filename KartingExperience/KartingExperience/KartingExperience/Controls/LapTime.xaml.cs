using KartingExperience.Models;
using KartingExperience.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KartingExperience.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LapTime : ViewCell
    {
        public LapTime()
        {
            InitializeComponent();
        }

        private void DeleteTime(object sender, EventArgs e)
        {

            int id = (int)((Button)sender).CommandParameter;
            int trackId = TrackListHandler.Database.LapsTime_DB.FirstOrDefault(t => t.Id == id).TrackId;

            var time = TrackListHandler.Database.LapsTime_DB.FirstOrDefault(t => t.Id == id);

            TrackListHandler.Database.LapsTime_DB.Remove(time);
            TrackListHandler.Database.SaveChanges();
             
            var track = TrackListHandler.Database.Tracks_DB.FirstOrDefault(t => t.Id == trackId);
            List<LapTimeModel> timesList = new List<LapTimeModel>();

            if (time.Time == track.BestLapTime)
            {
                float bestTime = float.MaxValue;

                foreach (var t in TrackListHandler.Database.LapsTime_DB)
                {
                    if (t.TrackId == trackId)
                    {
                        timesList.Add(t);
                    }
                }

                foreach(var t in timesList)
                {
                    if(t.Time < bestTime)
                    {
                        bestTime = t.Time;
                    }
                }

                track.BestLapTime = bestTime;
            }

            track.AverageTime = GetAverageLapTime(timesList);
            TrackListHandler.Database.SaveChanges();

            Application.Current.MainPage = new TrackDetailsPage();

        }

        private float GetAverageLapTime(List<LapTimeModel> lapList)
        {

            float AverageTime = 0;

            foreach (var time in lapList)
            {

                AverageTime += time.Time;

            }

            AverageTime /= lapList.Count;
            AverageTime = (float)Math.Round(AverageTime, 3);


            return AverageTime;

        }
    }
}