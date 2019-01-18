using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Position
    {
        public int PositionId { get; set; }

        [Display(Name = "Position name")]
        [Required(ErrorMessage = "Position name cannot be empty")]
        public string Name { get; set; }
        
        [Display(Name = "Gamer profiles")]
        public IEnumerable<GamerProfile> GamerProfiles{ get; set; }
    }
}