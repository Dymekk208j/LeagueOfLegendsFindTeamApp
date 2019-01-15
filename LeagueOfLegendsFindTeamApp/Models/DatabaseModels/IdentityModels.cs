using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
   
        [Display(Name = "Zablokowany")]
        public bool Blocked { get; set; }

        public static string GetUserName(string guid)
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            return applicationDbContext.Users.FirstOrDefault(a => a.Id == guid)?.UserName ?? " - ";
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.CommandTimeout = 900;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public virtual DbSet<Contact> Contacts { get; set; }

        public new virtual int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}