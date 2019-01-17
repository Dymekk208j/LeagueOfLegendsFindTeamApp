using System.Collections.Generic;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class GamerProfile
    {
        public int GamerProfileId { get; set; }
        public string InGameName { get; set; }
        public Position PrimaryPosition { get; set; }
        public Position SecondaryPosition { get; set; }
        public Region Region { get; set; }
        public bool ConfirmedAccount { get; set; }
        public Contact ContactDetails { get; set; }
        public Person Person { get; set; }
        public IEnumerable<Champion> ChampionsPool { get; set; }
        public League SoloQLeague { get; set; }
        public League FlexLeague { get; set; }
        public League League3 { get; set; }
        public IEnumerable<JoinRequest> JoinRequests { get; set; }
    }
}