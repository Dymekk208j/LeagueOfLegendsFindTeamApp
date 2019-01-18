using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class QueueType
    {
        public int QueueTypeId { get; set; }

        [Display(Name = "Queue name")]
        [Required(ErrorMessage = "Queue name cannot be empty")]
        public string Name { get; set; }
    }
}