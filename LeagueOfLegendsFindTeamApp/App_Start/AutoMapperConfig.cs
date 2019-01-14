using AutoMapper;

namespace LeagueOfLegendsFindTeamApp
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                //config.CreateMap<AboutMeViewModel, AboutMe>().ReverseMap();
            });
        }
    }
}