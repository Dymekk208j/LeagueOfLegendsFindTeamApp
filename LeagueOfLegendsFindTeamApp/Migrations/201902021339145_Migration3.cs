namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "ContactId", "dbo.People");
            DropForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts");
            DropIndex("dbo.Contacts", new[] { "ContactId" });
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "ContactId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contacts", "ContactId");
            AddForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts");
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "ContactId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contacts", "ContactId");
            CreateIndex("dbo.Contacts", "ContactId");
            AddForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts", "ContactId");
            AddForeignKey("dbo.Contacts", "ContactId", "dbo.People", "PersonId");
        }
    }
}
