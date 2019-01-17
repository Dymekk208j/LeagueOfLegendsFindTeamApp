namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    public class Champion
    {
        public string ChampionId { get; set; }
        public Image Portrait { get; set; }
        public Image SmallImage { get; set; }
        public string Name { get; set; }
    }
}
