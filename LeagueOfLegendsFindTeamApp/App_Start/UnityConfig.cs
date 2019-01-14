using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace LeagueOfLegendsFindTeamApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //container.RegisterType<IRepository<AboutMe, int>, AboutMeRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}