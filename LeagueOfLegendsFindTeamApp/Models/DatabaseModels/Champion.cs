using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Champion
    {
        public string ChampionId { get; set; }

        [Display(Name = "Portrait")]
        [Required(ErrorMessage = "Portrait cannot be empty")]
        public Image Portrait { get; set; }

        [Display(Name = "Small image")]
        [Required(ErrorMessage = "Image cannot be empty")]
        public Image SmallImage { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name field cannot be empty.")]
        [MinLength(3, ErrorMessage = "Name cannot be shorter than three chars")]
        public string Name { get; set; }

    }
}
