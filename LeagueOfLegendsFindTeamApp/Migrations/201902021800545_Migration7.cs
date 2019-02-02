namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Champions", "Icon_ImageId", "dbo.Images");
            DropForeignKey("dbo.Champions", "Portrait_ImageId", "dbo.Images");
            DropIndex("dbo.Champions", new[] { "Icon_ImageId" });
            DropIndex("dbo.Champions", new[] { "Portrait_ImageId" });
            DropTable("dbo.Champions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Champions",
                c => new
                    {
                        ChampionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Icon_ImageId = c.Int(nullable: false),
                        Portrait_ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.ChampionId);
            
            CreateIndex("dbo.Champions", "Portrait_ImageId");
            CreateIndex("dbo.Champions", "Icon_ImageId");
            AddForeignKey("dbo.Champions", "Portrait_ImageId", "dbo.Images", "ImageId");
            AddForeignKey("dbo.Champions", "Icon_ImageId", "dbo.Images", "ImageId", cascadeDelete: true);
        }
    }
}
