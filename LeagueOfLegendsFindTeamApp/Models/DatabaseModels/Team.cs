using System.Collections.Generic;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public Image Logo { get; set; }
        public GamerProfile Leader { get; set; }
        public IEnumerable<GamerProfile> Members { get; set; }
        public IEnumerable<QueueType> QueueTypes { get; set; }
        public IEnumerable<TeamType> TeamTypes { get; set; }
        public League AvgLeague { get; set; }
        public bool VoiceCommunication { get; set; }

    }
}