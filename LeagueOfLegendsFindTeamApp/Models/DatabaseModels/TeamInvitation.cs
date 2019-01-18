using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class TeamInvitation
    {
        public int TeamInvitationId { get; set; }

        [Display(Name = "Team")]
        public Team Team { get; set; }

        [Display(Name = "Gamer offer")]
        public GamerOffer GamerOffer { get; set; }

        [Display(Name = "Date of application")]
        [Required(ErrorMessage = "Date of application cannot be empty")]
        public DateTime DateOfApplication { get; set; }

        [Display(Name = "Expiration date")]
        [Required(ErrorMessage = "Expiration dater cannot be empty")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Selected positions")]
        [Required(ErrorMessage = "Selected positions cannot be empty")]
        public IEnumerable<Position> Positions { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessage= "Language cannot be empty")]
        public Language Language { get; set; }
    }
}