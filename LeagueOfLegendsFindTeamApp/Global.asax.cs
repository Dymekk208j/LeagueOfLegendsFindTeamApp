using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels.DatabaseContext;

namespace LeagueOfLegendsFindTeamApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(config =>
            {
                //config.CreateMap<ApplicationUser, UpdateViewModel>().ReverseMap();
            });

            Database.SetInitializer(new DbInitializer());
            UnityConfig.RegisterComponents();
        }
    }
}
