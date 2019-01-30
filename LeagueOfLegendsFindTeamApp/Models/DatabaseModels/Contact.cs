using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Display(Name = "Skype Account Id")]
        public string SkypeId { get; set; }

        [Display(Name = "Discord Account Id")]
        public string DiscordId { get; set; }

        [Display(Name = "Phone no")]
        public string PhoneNo { get; set; }

        [Display(Name = "Facebook link")]
        public string FacebookLink { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}