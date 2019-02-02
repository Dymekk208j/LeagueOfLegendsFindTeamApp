namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Champions");
            AlterColumn("dbo.Champions", "ChampionId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Champions", "ChampionId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Champions");
            AlterColumn("dbo.Champions", "ChampionId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Champions", "ChampionId");
        }
    }
}
