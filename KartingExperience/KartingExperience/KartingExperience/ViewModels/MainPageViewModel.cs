using KartingExperience.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using KartingExperience.Pages;
using System.Windows.Input;

namespace KartingExperience
{
    class MainPageViewModel : BaseViewModel
    {

        public ObservableCollection<TrackModel> LocalTrackList { get; set; } = new ObservableCollection<TrackModel>();

        public MainPageViewModel()
        {
       
            LocalTrackList = TrackListHandler.TrackList;

            //Console.WriteLine(LocalTrackList.Count);
            //Console.WriteLine(TrackListHandler.TrackList.Count);

        }

    }
}
