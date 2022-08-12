using KartingExperience.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KartingExperience.Database
{
    class KartExpDbContext : DbContext
    {

        public DbSet<TrackModel> Tracks_DB { get; set; }
        public DbSet<LapTimeModel> LapsTime_DB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite($"Filename={Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "KartExptest4.sqlite")}");

        }

    }
}
