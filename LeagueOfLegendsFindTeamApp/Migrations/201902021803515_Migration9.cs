namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration9 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ChampionId)
                .ForeignKey("dbo.Images", t => t.Icon_ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.Portrait_ImageId)
                .Index(t => t.Icon_ImageId)
                .Index(t => t.Portrait_ImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Champions", "Portrait_ImageId", "dbo.Images");
            DropForeignKey("dbo.Champions", "Icon_ImageId", "dbo.Images");
            DropIndex("dbo.Champions", new[] { "Portrait_ImageId" });
            DropIndex("dbo.Champions", new[] { "Icon_ImageId" });
            DropTable("dbo.Champions");
        }
    }
}
