using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public enum Division
    {
        [Display(Name = "Iron")]
        Iron,

        [Display(Name = "Bronze")]
        Bronze,

        [Display(Name = "Silver")]
        Silver,

        [Display(Name = "Gold")]
        Gold,

        [Display(Name = "Platinum")]
        Platinum,

        [Display(Name = "Diamond")]
        Diamond,

        [Display(Name = "Master")]
        Master,

        [Display(Name = "GrandMaster")]
        GrandMaster,

        [Display(Name = "Challenger")]
        Challenger
    }

    public class League
    {
        public int LeagueId { get; set; }

        [Display(Name = "League Name")]
        [Required(ErrorMessage = "League Name cannot be empty")]
        public string Name { get; set; }

        [Display(Name = "League division")]
        [Required(ErrorMessage = "League division cannot be empty")]
        public Division Division { get; set; }

        [Display(Name = "League value")]
        [Required(ErrorMessage = "League value cannot be empty")]
        public int LeagueValue { get; set; }

        [Display(Name = "League logo")]
        [Required(ErrorMessage = "League logo cannot be empty")]
        public Image Logo { get; set; }
    }
}