using KartingExperience.Models;
using KartingExperience.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KartingExperience
{
    class TrackDetailsPageViewModel : BaseViewModel
    {

        public static int Id { get; set; }

        public TrackModel Track { get; set; } = new TrackModel();

        public ObservableCollection<LapTimeModel> LapsTimesList { get; set; } = new ObservableCollection<LapTimeModel>();

        public string BestLapTime { get; set; }
        public string AverageTime { get; set; }

        public string NewLapTime { get; set; }

        public string Error { get; set; }

        public ICommand AddLapTimeCommand { get; set; }
        public ICommand DeleteTrackCommand { get; set; }


        public TrackDetailsPageViewModel()
        {

            Track = TrackListHandler.TrackList.FirstOrDefault(x => x.Id == Id);

            BestLapTime = Track.BestLapTime.ToString();
            AverageTime = Track.AverageTime.ToString();

            foreach(LapTimeModel lap in TrackListHandler.Database.LapsTime_DB)
            {
                if(lap.TrackId == Track.Id)
                {
                    LapsTimesList.Add(lap);
                }
            }

            AddLapTimeCommand = new RelayCommand(AddTimeLap);
            DeleteTrackCommand = new RelayCommand(DeleteTrack);

        }

        private void AddTimeLap()
        {

            if (float.TryParse(NewLapTime, out float p))
            {

                var lapTime = new LapTimeModel
                {

                    Time = (float)Math.Round(float.Parse(NewLapTime), 3),
                    TrackId = Id

                };

                if(lapTime.Time < Track.BestLapTime)
                {

                    Track.BestLapTime = lapTime.Time;

                }

                Track.AverageTime = GetAverageLapTime(LapsTimesList);

                TrackListHandler.Database.LapsTime_DB.Add(lapTime);
                TrackListHandler.Database.SaveChanges();

                BestLapTime = Track.BestLapTime.ToString();
                AverageTime = Track.AverageTime.ToString();

                Application.Current.MainPage = new TrackDetailsPage();

            }
            else
            {

                Error = "Invalid lap time";
                NewLapTime = string.Empty;

            }
        }

        private void DeleteTrack()
        {
            var trackToRemove = TrackListHandler.Database.Tracks_DB.FirstOrDefault(t => t.Id == Id);

            var trackFromTrackList = TrackListHandler.TrackList.FirstOrDefault(t => t.Id == Id);
            TrackListHandler.TrackList.Remove(trackFromTrackList);

            TrackListHandler.Database.LapsTime_DB.RemoveRange(LapsTimesList.ToList());
            TrackListHandler.Database.Tracks_DB.Remove(trackToRemove);
            TrackListHandler.Database.SaveChanges();

            App.Current.MainPage = new MainPage();
        }

        private float GetAverageLapTime(ObservableCollection<LapTimeModel> lapList)
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
