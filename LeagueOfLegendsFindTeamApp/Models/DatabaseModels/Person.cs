﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Person
    {
        public int PersonId { get; set; }

        [Display(Name = "First Name")]
        [MinLength(3, ErrorMessage = "First Name cannot be shorter then 3 chars")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Languages")]
        public List<Language> Languages { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }


}