namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Contacts", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Contacts", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Contacts", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Contacts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Contacts", "ApplicationUser_Id");
        }
    }
}
