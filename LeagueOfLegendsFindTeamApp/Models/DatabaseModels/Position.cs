using System.Collections.Generic;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Position
    {
        public int PositionId { get; set; }
        public string name { get; set; }
        public IEnumerable<GamerProfile> GamerProfiles{ get; set; }
    }
}