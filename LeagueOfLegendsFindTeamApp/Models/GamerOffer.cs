using System.Collections.Generic;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;

namespace LeagueOfLegendsFindTeamApp.Models
{
    public class GamerOffer
    {
        public int GamerOfferId { get; set; }
        public League RequiredMinAvLeague { get; set; }
        public League RequiredMaxAvLeague { get; set; }
        public bool RequiredVoiceCommunication { get; set; }
        public GamerProfile GamerProfile { get; set; }
        public IEnumerable<TeamInvitation> Invitations { get; set; }
    }
}