namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ImageTitlePropAddedToImageModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Title");
        }
    }
}
