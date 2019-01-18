namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModels2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Url", c => c.String());
            DropColumn("dbo.Images", "Guid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Guid", c => c.Guid(nullable: false));
            DropColumn("dbo.Images", "Url");
        }
    }
}
