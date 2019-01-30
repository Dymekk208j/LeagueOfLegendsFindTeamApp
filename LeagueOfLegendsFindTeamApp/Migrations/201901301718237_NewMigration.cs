namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.GamerProfiles", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.People", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Contacts", "ApplicationUser_Id");
            CreateIndex("dbo.GamerProfiles", "ApplicationUser_Id");
            CreateIndex("dbo.People", "ApplicationUser_Id");
            AddForeignKey("dbo.GamerProfiles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.People", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Contacts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.People", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GamerProfiles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.People", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.GamerProfiles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Contacts", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.People", "ApplicationUser_Id");
            DropColumn("dbo.GamerProfiles", "ApplicationUser_Id");
            DropColumn("dbo.Contacts", "ApplicationUser_Id");
        }
    }
}
