using KartingExperience.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using KartingExperience.Database;
using System.Linq;

namespace KartingExperience
{
    static class TrackListHandler
    {

        public static ObservableCollection<TrackModel> TrackList { get; set; } = new ObservableCollection<TrackModel>();
        public static KartExpDbContext Database { get; set; }

        public static void GetData()
        {

            foreach (var track in Database.Tracks_DB.ToList())
            {

                TrackList.Add(new TrackModel
                {

                    Id = track.Id,
                    TrackName = track.TrackName,
                    BestLapTime = track.BestLapTime,
                    AverageTime = track.AverageTime

                });

            }

        }

    }
}
