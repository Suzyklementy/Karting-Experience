using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KartingExperience.Models
{
    class LapTimeModel
    {

        public int Id { get; set; }
        public float Time { get; set; }

        public int TrackId { get; set; }
        public virtual TrackModel Track { get; set; }

    }
}
