using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class TeamType
    {
        public int TeamTypeId { get; set; }

        [Display(Name = "Team type")]
        [Required(ErrorMessage = "Team type cannot be empty")]
        public string Name { get; set; }
    }
}