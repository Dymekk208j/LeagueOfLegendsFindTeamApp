using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels.DatabaseContext
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Damian",
                LastName = "Dziura",
                UserName = "Dymek",
                Blocked = false,
                Email = "Kontakt@damiandziura.pl"
            };

            userManager.Create(user, "Damian13");

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            userManager.AddToRole(user.Id, "Admin");
        }
    }
}