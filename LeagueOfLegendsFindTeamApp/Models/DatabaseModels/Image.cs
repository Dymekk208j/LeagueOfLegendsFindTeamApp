using System;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Image
    {
        public int ImageId { get; set; }

        [Display(Name = "File name")]
        [Required(ErrorMessage = "File name cannot be empty")]
        public string FileName { get; set; }

        [Display(Name = "Guid")]
        [Required(ErrorMessage = "Guid")]
        public Guid Guid { get; set; }
    }
}