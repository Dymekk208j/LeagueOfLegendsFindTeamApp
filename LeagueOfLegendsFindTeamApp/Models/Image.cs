using System;

namespace LeagueOfLegendsFindTeamApp.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public string Link { get; set; }
        public Guid Guid { get; set; }
    }
}