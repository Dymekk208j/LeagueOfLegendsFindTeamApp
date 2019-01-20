namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ImageTypePropAddedToImageModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageType");
        }
    }
}
