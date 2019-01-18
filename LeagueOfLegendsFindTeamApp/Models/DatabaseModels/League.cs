using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class League
    {
        public int LeagueId { get; set; }

        [Display(Name = "League Name")]
        [Required(ErrorMessage = "League Name cannot be empty")]
        public string Name { get; set; }

        [Display(Name = "League division")]
        [Required(ErrorMessage = "League division cannot be empty")]
        public int Division { get; set; }

        [Display(Name = "League value")]
        [Required(ErrorMessage = "League value cannot be empty")]
        public int LeagueValue { get; set; }

        [Display(Name = "League logo")]
        [Required(ErrorMessage = "League logo cannot be empty")]
        public Image Logo { get; set; }
    }
}