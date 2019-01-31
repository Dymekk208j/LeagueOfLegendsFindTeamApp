namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Languages", "Person_PersonId", c => c.Int());
            CreateIndex("dbo.Languages", "Person_PersonId");
            AddForeignKey("dbo.Languages", "Person_PersonId", "dbo.People", "PersonId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Languages", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Languages", new[] { "Person_PersonId" });
            DropColumn("dbo.Languages", "Person_PersonId");
        }
    }
}
