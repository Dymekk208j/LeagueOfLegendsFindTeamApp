using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeagueOfLegendsFindTeamApp.Startup))]
namespace LeagueOfLegendsFindTeamApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
