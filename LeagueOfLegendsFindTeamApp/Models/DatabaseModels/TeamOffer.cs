using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class TeamOffer
    {
        public int TeamOfferId { get; set; }

        [Display(Name = "Wanted positions")]
        [Required(ErrorMessage = "Wanted positions cannot be empty")]
        public IEnumerable<Position> WantedPositions { get; set; }

        [Display(Name = "Team")]
        [Required(ErrorMessage = "Team cannot be empty")]
        public Team Team { get; set; }

        [Display(Name = "Date of offer")]
        [Required(ErrorMessage = "Date of offer cannot be empty")]
        public DateTime DateOfOffer { get; set; }

        [Display(Name = "Expiration date")]
        [Required(ErrorMessage = "Expiration date cannot be empty")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Join requests")]
        public IEnumerable<JoinRequest> JoinRequests { get; set; }

        [Display(Name = "Required minimum gamer league")]
        public League RequiredMinLeague { get; set; }

        [Display(Name = "Required maximum gamer league")]
        public League RequiredMaxLeague { get; set; }

        [Display(Name = "Required languages")]
        [Required(ErrorMessage = "Required languages cannot be empty")]
        public IEnumerable<Language> RequiredLanguages { get; set; }

        [Display(Name = "Required voice communication")]
        public bool RequiredVoiceCommunication { get; set; }
    }
}