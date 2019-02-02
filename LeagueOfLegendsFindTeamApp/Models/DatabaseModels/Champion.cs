using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Champion
    {
        public int ChampionId { get; set; }

        [Display(Name = "Portrait")]
        public Image Portrait { get; set; }

        [Display(Name = "Icon")]
        [Required(ErrorMessage = "Champion icon cannot be empty")]
        public Image Icon { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name field cannot be empty.")]
        [MinLength(3, ErrorMessage = "Name cannot be shorter than three chars")]
        public string Name { get; set; }
    }
}