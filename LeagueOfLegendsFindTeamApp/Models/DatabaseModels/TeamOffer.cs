using System;
using System.Collections.Generic;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class TeamOffer
    {
        public int TeamOfferId { get; set; }
        public IEnumerable<Position> WantedPositions { get; set; }
        public Team Team { get; set; }
        public DateTime DateOfOffer { get; set; }
        public DateTime ExpirationDate { get; set; }
        public IEnumerable<JoinRequest> JoinRequests { get; set; }
        public League RequiredMinLeague { get; set; }
        public League RequiredMaxLeague { get; set; }
        public IEnumerable<Language> RequiredLanguages { get; set; }
        public bool RequiredVoiceCommunication { get; set; }
    }
}