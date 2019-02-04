namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.GamerProfiles", "Person_PersonId", "dbo.People");
            DropIndex("dbo.GamerProfiles", new[] { "ContactDetails_ContactId" });
            DropIndex("dbo.GamerProfiles", new[] { "Person_PersonId" });
            AddColumn("dbo.GamerProfiles", "ConfirmedInGameName", c => c.Boolean(nullable: false));
            DropColumn("dbo.GamerProfiles", "ConfirmedAccount");
            DropColumn("dbo.GamerProfiles", "ContactDetails_ContactId");
            DropColumn("dbo.GamerProfiles", "Person_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GamerProfiles", "Person_PersonId", c => c.Int());
            AddColumn("dbo.GamerProfiles", "ContactDetails_ContactId", c => c.Int());
            AddColumn("dbo.GamerProfiles", "ConfirmedAccount", c => c.Boolean(nullable: false));
            DropColumn("dbo.GamerProfiles", "ConfirmedInGameName");
            CreateIndex("dbo.GamerProfiles", "Person_PersonId");
            CreateIndex("dbo.GamerProfiles", "ContactDetails_ContactId");
            AddForeignKey("dbo.GamerProfiles", "Person_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts", "ContactId");
        }
    }
}
