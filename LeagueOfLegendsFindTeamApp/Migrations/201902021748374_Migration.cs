namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Champions", "Portrait_ImageId", "dbo.Images");
            DropForeignKey("dbo.Champions", "SmallImage_ImageId", "dbo.Images");
            DropIndex("dbo.Champions", new[] { "Portrait_ImageId" });
            DropIndex("dbo.Champions", new[] { "SmallImage_ImageId" });
            RenameColumn(table: "dbo.Champions", name: "SmallImage_ImageId", newName: "Icon_ImageId");
            AlterColumn("dbo.Champions", "Portrait_ImageId", c => c.Int());
            AlterColumn("dbo.Champions", "Icon_ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Champions", "Icon_ImageId");
            CreateIndex("dbo.Champions", "Portrait_ImageId");
            AddForeignKey("dbo.Champions", "Portrait_ImageId", "dbo.Images", "ImageId");
            AddForeignKey("dbo.Champions", "Icon_ImageId", "dbo.Images", "ImageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Champions", "Icon_ImageId", "dbo.Images");
            DropForeignKey("dbo.Champions", "Portrait_ImageId", "dbo.Images");
            DropIndex("dbo.Champions", new[] { "Portrait_ImageId" });
            DropIndex("dbo.Champions", new[] { "Icon_ImageId" });
            AlterColumn("dbo.Champions", "Icon_ImageId", c => c.Int());
            AlterColumn("dbo.Champions", "Portrait_ImageId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Champions", name: "Icon_ImageId", newName: "SmallImage_ImageId");
            CreateIndex("dbo.Champions", "SmallImage_ImageId");
            CreateIndex("dbo.Champions", "Portrait_ImageId");
            AddForeignKey("dbo.Champions", "SmallImage_ImageId", "dbo.Images", "ImageId");
            AddForeignKey("dbo.Champions", "Portrait_ImageId", "dbo.Images", "ImageId", cascadeDelete: true);
        }
    }
}
