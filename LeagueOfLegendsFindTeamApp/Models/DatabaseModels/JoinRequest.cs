﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class JoinRequest
    {
        public int JoinRequestId { get; set; }

        [Display(Name = "Gamer profile")]
        [Required(ErrorMessage = "Gamer profile cannot be empty")]
        public GamerProfile GamerProfile { get; set; }

        [Display(Name = "Team offer")]
        [Required(ErrorMessage = "Team offer cannot be empty")]
        public TeamOffer TeamOffer { get; set; }

        [Display(Name = "Date of application")]
        [Required(ErrorMessage = "Date of application cannot be empty")]
        public DateTime DateOfApplication { get; set; }

        [Display(Name = "Expiration date")]
        [Required(ErrorMessage = "Expiration date cannot be empty")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Selected positions")]
        [Required(ErrorMessage = "Selected positions cannot be empty")]
        public IEnumerable<Position> SelectedPositions { get; set; }

    }
}