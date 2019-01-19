using LeagueOfLegendsFindTeamApp.Controllers;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace LeagueOfLegendsFindTeamApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IRepository<Language, int>, LanguageRepository>();
            container.RegisterType<IRepository<QueueType, int>, QueueTypeRepository>();
            container.RegisterType<IRepository<TeamType, int>, TeamTypeRepository>();
            container.RegisterType<IRepository<Position, int>, PositionRepository>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}