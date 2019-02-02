using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class GamerProfile
    {
        public int GamerProfileId { get; set; }

        [Display(Name = "Portrait")]
       // [Required(ErrorMessage = "Portrait cannot be empty")]
        public Image Portrait { get; set; }

        [Display(Name = "In game Name")]
       // [Required(ErrorMessage = "In game nickname cannot be empty")]
        [MinLength(5, ErrorMessage = "Your in game nickname cannot be shorter then 5 chars.")]
        public string InGameName { get; set; }

        [Display(Name = "Primary position")]
      //  [Required(ErrorMessage = "Primary position cannot be empty")]
        public Position PrimaryPosition { get; set; }

        [Display(Name = "Secondary position")]
        public Position SecondaryPosition { get; set; }

        [Display(Name = "Account region")]
      //  [Required(ErrorMessage = "Your account region cannot be empty")]
        public Region Region { get; set; }

        [Display(Name = "Confirmed Account")]
        public bool ConfirmedAccount { get; set; }

        [Display(Name = "Champions pool")]
        public IEnumerable<Champion> ChampionsPool { get; set; }

        [Display(Name = "Solo Q position")]
        public League SoloQLeague { get; set; }

        [Display(Name = "Flex queue position")]
        public League FlexLeague { get; set; }

        [Display(Name = "3 vs. 3 queue position")]
        public League League3 { get; set; }

        [Display(Name = "Join requests")]
        public IEnumerable<JoinRequest> JoinRequests { get; set; }

        [Display(Name = "Team invitations")]
        public IEnumerable<TeamInvitation> TeamInvitations { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}