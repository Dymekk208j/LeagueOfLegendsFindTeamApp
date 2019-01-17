using System;
using System.Collections.Generic;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;

namespace LeagueOfLegendsFindTeamApp.Models
{
    public class TeamInvitation
    {
        public int TeamInvitationId { get; set; }
        public Team Team { get; set; }
        public GamerOffer GamerOffer { get; set; }
        public DateTime DateOfApplication { get; set; }
        public DateTime ExpirationDate { get; set; }
        public IEnumerable<Position> Positions { get; set; }
        public Language Language { get; set; }
    }
}