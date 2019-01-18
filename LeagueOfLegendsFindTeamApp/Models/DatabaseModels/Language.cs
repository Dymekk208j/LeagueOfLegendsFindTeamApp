using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Language
    {
        public int LanguageId { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessage = "Language cannot be empty")]
        public string Name { get; set; }

    }
}