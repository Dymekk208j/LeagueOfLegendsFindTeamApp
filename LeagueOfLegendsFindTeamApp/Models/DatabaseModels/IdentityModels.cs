using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
   
        [Display(Name = "Blocked")]
        public bool Blocked { get; set; }

        public Person Person { get; set; }
        public GamerProfile GamerProfile { get; set; }

        public Contact ContactDetails { get; set; }
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

        public virtual DbSet<Champion> Champions { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<GamerOffer> GamerOffers { get; set; }
        public virtual DbSet<GamerProfile> GamerProfiles { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<JoinRequest> JoinRequests { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<QueueType> QueueTypes { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamInvitation> TeamInvitations { get; set; }
        public virtual DbSet<TeamOffer> TeamOffers { get; set; }
        public virtual DbSet<TeamType> TeamTypes { get; set; }


        public new virtual int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}