using System.Collections.Generic;

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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
    }
}