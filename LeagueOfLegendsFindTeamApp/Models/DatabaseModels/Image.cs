using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public enum ImageType
    {
        [Display(Name = "Division icon")]
        DivisionIcon,

        [Display(Name = "Player icon")]
        PlayerIcon,

        [Display(Name = "Team logo")]
        TeamLogo,

        [Display(Name = "Champion icon")]
        ChampionIcon,

        [Display(Name = "Champion portrait")]
        ChampionPortrait,

        [Display(Name = "Other")]
        Other
    }
    public class Image
    {
        public int ImageId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }

        [Display(Name = "File name")]
        public string FileName { get; set; }

        [Display(Name = "Url address")]
        [Required(ErrorMessage = "Url cannot be empty")]
        public string Url { get; set; }

        [Display(Name = "Image type")]
        public ImageType ImageType { get; set; }
    }
}