using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Input;
using KartingExperience.Pages;
using Microsoft.EntityFrameworkCore;

namespace KartingExperience.Models
{
    class TrackModel
    {

        public int Id { get; set; }

        public string TrackName { get; set; }

        public float BestLapTime { get; set; }

        public float AverageTime { get; set; }

        public virtual List<LapTimeModel> LapTimes { get; set; }

    }
}
