namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ImageModelUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Images", "Url", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "Url", c => c.String());
            AlterColumn("dbo.Images", "Title", c => c.String());
        }
    }
}
