using System.Collections.Generic;
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
        [Required(ErrorMessage = "First Name cannot be empty")]
        [MinLength(3, ErrorMessage = "First Name cannot be shorter then 3 chars")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [Display(Name = "Languages")]
        [Required(ErrorMessage = "Languages cannot be empty")]
        public IEnumerable<Language> Languages { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country cannot be empty")]
        public string Country { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
    }
}