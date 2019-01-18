using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class GamerOffer
    {
        public int GamerOfferId { get; set; }

        [Display(Name = "Required minimum team league")]
        public League RequiredMinAvLeague { get; set; }

        [Display(Name = "Required maximum team league")]
        public League RequiredMaxAvLeague { get; set; }

        [Display(Name = "Required voice communication")]
        public bool RequiredVoiceCommunication { get; set; }

        [Display(Name = "Gamer profile")]
        [Required(ErrorMessage = "Gamer profile cannot be empty")]
        public GamerProfile GamerProfile { get; set; }

        [Display(Name = "Invitations")]
        public IEnumerable<TeamInvitation> Invitations { get; set; }
    }
}