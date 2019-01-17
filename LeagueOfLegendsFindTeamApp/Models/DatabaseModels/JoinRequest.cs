using System;
using System.Collections.Generic;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class JoinRequest
    {
        public int JoinRequestId { get; set; }
        public GamerProfile GamerProfile { get; set; }
        public TeamOffer TeamOffer { get; set; }
        public DateTime DateOfApplication { get; set; }
        public DateTime ExpirationDate { get; set; }
        public IEnumerable<Position> SelectedPositions { get; set; }

    }
}