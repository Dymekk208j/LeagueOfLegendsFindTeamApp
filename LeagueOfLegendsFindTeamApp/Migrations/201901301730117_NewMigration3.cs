namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.GamerProfiles", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.GamerProfiles", "Portrait_ImageId", "dbo.Images");
            DropForeignKey("dbo.GamerProfiles", "PrimaryPosition_PositionId", "dbo.Positions");
            DropForeignKey("dbo.GamerProfiles", "Region_RegionId", "dbo.Regions");
            DropIndex("dbo.GamerProfiles", new[] { "ContactDetails_ContactId" });
            DropIndex("dbo.GamerProfiles", new[] { "Person_PersonId" });
            DropIndex("dbo.GamerProfiles", new[] { "Portrait_ImageId" });
            DropIndex("dbo.GamerProfiles", new[] { "PrimaryPosition_PositionId" });
            DropIndex("dbo.GamerProfiles", new[] { "Region_RegionId" });
            AlterColumn("dbo.GamerProfiles", "InGameName", c => c.String());
            AlterColumn("dbo.GamerProfiles", "ContactDetails_ContactId", c => c.Int());
            AlterColumn("dbo.GamerProfiles", "Person_PersonId", c => c.Int());
            AlterColumn("dbo.GamerProfiles", "Portrait_ImageId", c => c.Int());
            AlterColumn("dbo.GamerProfiles", "PrimaryPosition_PositionId", c => c.Int());
            AlterColumn("dbo.GamerProfiles", "Region_RegionId", c => c.Int());
            AlterColumn("dbo.People", "FirstName", c => c.String());
            AlterColumn("dbo.People", "Country", c => c.String());
            CreateIndex("dbo.GamerProfiles", "ContactDetails_ContactId");
            CreateIndex("dbo.GamerProfiles", "Person_PersonId");
            CreateIndex("dbo.GamerProfiles", "Portrait_ImageId");
            CreateIndex("dbo.GamerProfiles", "PrimaryPosition_PositionId");
            CreateIndex("dbo.GamerProfiles", "Region_RegionId");
            AddForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts", "ContactId");
            AddForeignKey("dbo.GamerProfiles", "Person_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.GamerProfiles", "Portrait_ImageId", "dbo.Images", "ImageId");
            AddForeignKey("dbo.GamerProfiles", "PrimaryPosition_PositionId", "dbo.Positions", "PositionId");
            AddForeignKey("dbo.GamerProfiles", "Region_RegionId", "dbo.Regions", "RegionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamerProfiles", "Region_RegionId", "dbo.Regions");
            DropForeignKey("dbo.GamerProfiles", "PrimaryPosition_PositionId", "dbo.Positions");
            DropForeignKey("dbo.GamerProfiles", "Portrait_ImageId", "dbo.Images");
            DropForeignKey("dbo.GamerProfiles", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts");
            DropIndex("dbo.GamerProfiles", new[] { "Region_RegionId" });
            DropIndex("dbo.GamerProfiles", new[] { "PrimaryPosition_PositionId" });
            DropIndex("dbo.GamerProfiles", new[] { "Portrait_ImageId" });
            DropIndex("dbo.GamerProfiles", new[] { "Person_PersonId" });
            DropIndex("dbo.GamerProfiles", new[] { "ContactDetails_ContactId" });
            AlterColumn("dbo.People", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.GamerProfiles", "Region_RegionId", c => c.Int(nullable: false));
            AlterColumn("dbo.GamerProfiles", "PrimaryPosition_PositionId", c => c.Int(nullable: false));
            AlterColumn("dbo.GamerProfiles", "Portrait_ImageId", c => c.Int(nullable: false));
            AlterColumn("dbo.GamerProfiles", "Person_PersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.GamerProfiles", "ContactDetails_ContactId", c => c.Int(nullable: false));
            AlterColumn("dbo.GamerProfiles", "InGameName", c => c.String(nullable: false));
            CreateIndex("dbo.GamerProfiles", "Region_RegionId");
            CreateIndex("dbo.GamerProfiles", "PrimaryPosition_PositionId");
            CreateIndex("dbo.GamerProfiles", "Portrait_ImageId");
            CreateIndex("dbo.GamerProfiles", "Person_PersonId");
            CreateIndex("dbo.GamerProfiles", "ContactDetails_ContactId");
            AddForeignKey("dbo.GamerProfiles", "Region_RegionId", "dbo.Regions", "RegionId", cascadeDelete: true);
            AddForeignKey("dbo.GamerProfiles", "PrimaryPosition_PositionId", "dbo.Positions", "PositionId", cascadeDelete: true);
            AddForeignKey("dbo.GamerProfiles", "Portrait_ImageId", "dbo.Images", "ImageId", cascadeDelete: true);
            AddForeignKey("dbo.GamerProfiles", "Person_PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
    }
}
