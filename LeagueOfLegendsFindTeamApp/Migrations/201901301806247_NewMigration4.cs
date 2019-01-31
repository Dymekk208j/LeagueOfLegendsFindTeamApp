namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Nickname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Nickname", c => c.String());
        }
    }
}
