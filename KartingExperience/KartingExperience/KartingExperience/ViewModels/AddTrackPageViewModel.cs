using KartingExperience.Models;
using KartingExperience.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace KartingExperience
{
    class AddTrackPageViewModel : BaseViewModel
    {

        public string NewTrackName { get; set; }
        public ObservableCollection<LapTimeModel> NewLapsTimesList { get; set; } = new ObservableCollection<LapTimeModel>();
        public string NewLapTime { get; set; }
        public string Error { get; set; }

        public ICommand AddLapTimeCommand { get; set; }
        public ICommand AddTrackCommand { get; set; }

        public AddTrackPageViewModel()
        {

            AddLapTimeCommand = new RelayCommand(AddTimeLap);
            AddTrackCommand = new RelayCommand(AddTrack);

        }

        private void AddTimeLap()
        {

            if(float.TryParse(NewLapTime, out float p))
            {

                var lapTime = (new LapTimeModel
                {

                    Time = (float)Math.Round(float.Parse(NewLapTime), 3)

                });

                NewLapsTimesList.Add(lapTime);

                NewLapTime = string.Empty;

            }
            else
            {

                Error = "Invalid lap time";
                NewLapTime = string.Empty;

            }

 

        }

        private void AddTrack()
        {

            if(!string.IsNullOrWhiteSpace(NewTrackName) && NewTrackName.Length < 20 && NewLapsTimesList.Count > 0)
            {

                var newTrack = new TrackModel
                {

                    TrackName = NewTrackName,
                    BestLapTime = GetBestLap(NewLapsTimesList),
                    AverageTime = GetAverageLapTime(NewLapsTimesList),
                    LapTimes = NewLapsTimesList.ToList()

                };


                TrackListHandler.TrackList.Add(newTrack);

                TrackListHandler.Database.Tracks_DB.Add(newTrack);
                TrackListHandler.Database.SaveChanges();

                App.Current.MainPage = new MainPage();

            }
            else
            {

                Error = "Track name is empty or has more than 20 character or has 0 laps times";
                NewTrackName = string.Empty;

            }

        }

        public float GetBestLap(ObservableCollection<LapTimeModel> lapList)
        {

            float bestTime = float.MaxValue;

            foreach(var time in lapList)
            {

                if(time.Time < bestTime)
                {

                    bestTime = time.Time;

                }

            }

            return bestTime;

        }

        public float GetAverageLapTime(ObservableCollection<LapTimeModel> lapList)
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
