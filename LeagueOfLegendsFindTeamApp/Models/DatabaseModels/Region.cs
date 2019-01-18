using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Region
    {
        public int RegionId { get; set; }

        [Display(Name = "Region name")]
        [Required(ErrorMessage = "Region name cannot be empty")]
        public string Name { get; set; }

        [Display(Name = "Gamer profiles")]
        public IEnumerable<GamerProfile> GamerProfiles { get; set; }
    }
}