using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab3
{
    class Song : Media
    {
        public string Album { get; set; }
        public string Artist { get; set; }

        public Song(string title, int year, string Album, string Artist) : base(title,year)
        {
            this.Title = title;
            this.Year = year;
            this.Album = Album;
            this.Artist = Artist;
        }
    }
}

