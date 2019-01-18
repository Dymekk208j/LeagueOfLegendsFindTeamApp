using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Team
    {
        public int TeamId { get; set; }

        [Display(Name = "Team name")]
        [Required(ErrorMessage = "Team name cannot be empty")]
        [MinLength(5, ErrorMessage = "Team name cannot be shorter then 5 chars")]
        [MaxLength(250)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public Image Logo { get; set; }

        [Display(Name = "Team leader")]
        public GamerProfile Leader { get; set; }

        [Display(Name = "Members")]
        public IEnumerable<GamerProfile> Members { get; set; }

        [Display(Name = "Queue types")]
        public IEnumerable<QueueType> QueueTypes { get; set; }

        [Display(Name = "Team types")]
        public IEnumerable<TeamType> TeamTypes { get; set; }

        [Display(Name = "Team league(Average of members)")]
        public League AvgLeague { get; set; }

        [Display(Name = "Required voice communication")]
        public bool VoiceCommunication { get; set; }

    }
}