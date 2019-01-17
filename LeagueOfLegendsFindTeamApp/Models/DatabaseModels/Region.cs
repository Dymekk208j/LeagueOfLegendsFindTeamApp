using System.Collections.Generic;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public IEnumerable<GamerProfile> GamerProfiles { get; set; }
    }
}