namespace LeagueOfLegendsFindTeamApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Champions",
                c => new
                    {
                        ChampionId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Portrait_ImageId = c.Int(nullable: false),
                        SmallImage_ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.ChampionId)
                .ForeignKey("dbo.Images", t => t.Portrait_ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.SmallImage_ImageId)
                .Index(t => t.Portrait_ImageId)
                .Index(t => t.SmallImage_ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        SkypeId = c.String(),
                        DiscordId = c.String(),
                        PhoneNo = c.String(),
                        FacebookLink = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.GamerOffers",
                c => new
                    {
                        GamerOfferId = c.Int(nullable: false, identity: true),
                        RequiredVoiceCommunication = c.Boolean(nullable: false),
                        GamerProfile_GamerProfileId = c.Int(nullable: false),
                        RequiredMaxAvLeague_LeagueId = c.Int(),
                        RequiredMinAvLeague_LeagueId = c.Int(),
                    })
                .PrimaryKey(t => t.GamerOfferId)
                .ForeignKey("dbo.GamerProfiles", t => t.GamerProfile_GamerProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Leagues", t => t.RequiredMaxAvLeague_LeagueId)
                .ForeignKey("dbo.Leagues", t => t.RequiredMinAvLeague_LeagueId)
                .Index(t => t.GamerProfile_GamerProfileId)
                .Index(t => t.RequiredMaxAvLeague_LeagueId)
                .Index(t => t.RequiredMinAvLeague_LeagueId);
            
            CreateTable(
                "dbo.GamerProfiles",
                c => new
                    {
                        GamerProfileId = c.Int(nullable: false, identity: true),
                        InGameName = c.String(nullable: false),
                        ConfirmedAccount = c.Boolean(nullable: false),
                        ContactDetails_ContactId = c.Int(nullable: false),
                        FlexLeague_LeagueId = c.Int(),
                        League3_LeagueId = c.Int(),
                        Person_PersonId = c.Int(nullable: false),
                        Portrait_ImageId = c.Int(nullable: false),
                        PrimaryPosition_PositionId = c.Int(nullable: false),
                        Region_RegionId = c.Int(nullable: false),
                        SecondaryPosition_PositionId = c.Int(),
                        SoloQLeague_LeagueId = c.Int(),
                    })
                .PrimaryKey(t => t.GamerProfileId)
                .ForeignKey("dbo.Contacts", t => t.ContactDetails_ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Leagues", t => t.FlexLeague_LeagueId)
                .ForeignKey("dbo.Leagues", t => t.League3_LeagueId)
                .ForeignKey("dbo.People", t => t.Person_PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.Portrait_ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PrimaryPosition_PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.Region_RegionId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.SecondaryPosition_PositionId)
                .ForeignKey("dbo.Leagues", t => t.SoloQLeague_LeagueId)
                .Index(t => t.ContactDetails_ContactId)
                .Index(t => t.FlexLeague_LeagueId)
                .Index(t => t.League3_LeagueId)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Portrait_ImageId)
                .Index(t => t.PrimaryPosition_PositionId)
                .Index(t => t.Region_RegionId)
                .Index(t => t.SecondaryPosition_PositionId)
                .Index(t => t.SoloQLeague_LeagueId);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        LeagueId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Division = c.Int(nullable: false),
                        LeagueValue = c.Int(nullable: false),
                        Logo_ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeagueId)
                .ForeignKey("dbo.Images", t => t.Logo_ImageId, cascadeDelete: true)
                .Index(t => t.Logo_ImageId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Nickname = c.String(),
                        Country = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegionId);
            
            CreateTable(
                "dbo.JoinRequests",
                c => new
                    {
                        JoinRequestId = c.Int(nullable: false, identity: true),
                        DateOfApplication = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        GamerProfile_GamerProfileId = c.Int(nullable: false),
                        TeamOffer_TeamOfferId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JoinRequestId)
                .ForeignKey("dbo.GamerProfiles", t => t.GamerProfile_GamerProfileId, cascadeDelete: true)
                .ForeignKey("dbo.TeamOffers", t => t.TeamOffer_TeamOfferId, cascadeDelete: true)
                .Index(t => t.GamerProfile_GamerProfileId)
                .Index(t => t.TeamOffer_TeamOfferId);
            
            CreateTable(
                "dbo.TeamOffers",
                c => new
                    {
                        TeamOfferId = c.Int(nullable: false, identity: true),
                        DateOfOffer = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        RequiredVoiceCommunication = c.Boolean(nullable: false),
                        RequiredMaxLeague_LeagueId = c.Int(),
                        RequiredMinLeague_LeagueId = c.Int(),
                        Team_TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamOfferId)
                .ForeignKey("dbo.Leagues", t => t.RequiredMaxLeague_LeagueId)
                .ForeignKey("dbo.Leagues", t => t.RequiredMinLeague_LeagueId)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId, cascadeDelete: true)
                .Index(t => t.RequiredMaxLeague_LeagueId)
                .Index(t => t.RequiredMinLeague_LeagueId)
                .Index(t => t.Team_TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        VoiceCommunication = c.Boolean(nullable: false),
                        AvgLeague_LeagueId = c.Int(),
                        Leader_GamerProfileId = c.Int(),
                        Logo_ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Leagues", t => t.AvgLeague_LeagueId)
                .ForeignKey("dbo.GamerProfiles", t => t.Leader_GamerProfileId)
                .ForeignKey("dbo.Images", t => t.Logo_ImageId)
                .Index(t => t.Name, unique: true)
                .Index(t => t.AvgLeague_LeagueId)
                .Index(t => t.Leader_GamerProfileId)
                .Index(t => t.Logo_ImageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.QueueTypes",
                c => new
                    {
                        QueueTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.QueueTypeId);
            
            CreateTable(
                "dbo.TeamInvitations",
                c => new
                    {
                        TeamInvitationId = c.Int(nullable: false, identity: true),
                        DateOfApplication = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        GamerOffer_GamerOfferId = c.Int(),
                        Language_LanguageId = c.Int(nullable: false),
                        Team_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamInvitationId)
                .ForeignKey("dbo.GamerOffers", t => t.GamerOffer_GamerOfferId)
                .ForeignKey("dbo.Languages", t => t.Language_LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId)
                .Index(t => t.GamerOffer_GamerOfferId)
                .Index(t => t.Language_LanguageId)
                .Index(t => t.Team_TeamId);
            
            CreateTable(
                "dbo.TeamTypes",
                c => new
                    {
                        TeamTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeamTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamInvitations", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.TeamInvitations", "Language_LanguageId", "dbo.Languages");
            DropForeignKey("dbo.TeamInvitations", "GamerOffer_GamerOfferId", "dbo.GamerOffers");
            DropForeignKey("dbo.JoinRequests", "TeamOffer_TeamOfferId", "dbo.TeamOffers");
            DropForeignKey("dbo.TeamOffers", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Logo_ImageId", "dbo.Images");
            DropForeignKey("dbo.Teams", "Leader_GamerProfileId", "dbo.GamerProfiles");
            DropForeignKey("dbo.Teams", "AvgLeague_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.TeamOffers", "RequiredMinLeague_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.TeamOffers", "RequiredMaxLeague_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.JoinRequests", "GamerProfile_GamerProfileId", "dbo.GamerProfiles");
            DropForeignKey("dbo.GamerOffers", "RequiredMinAvLeague_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.GamerOffers", "RequiredMaxAvLeague_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.GamerOffers", "GamerProfile_GamerProfileId", "dbo.GamerProfiles");
            DropForeignKey("dbo.GamerProfiles", "SoloQLeague_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.GamerProfiles", "SecondaryPosition_PositionId", "dbo.Positions");
            DropForeignKey("dbo.GamerProfiles", "Region_RegionId", "dbo.Regions");
            DropForeignKey("dbo.GamerProfiles", "PrimaryPosition_PositionId", "dbo.Positions");
            DropForeignKey("dbo.GamerProfiles", "Portrait_ImageId", "dbo.Images");
            DropForeignKey("dbo.GamerProfiles", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.GamerProfiles", "League3_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.GamerProfiles", "FlexLeague_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.Leagues", "Logo_ImageId", "dbo.Images");
            DropForeignKey("dbo.GamerProfiles", "ContactDetails_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Champions", "SmallImage_ImageId", "dbo.Images");
            DropForeignKey("dbo.Champions", "Portrait_ImageId", "dbo.Images");
            DropIndex("dbo.TeamInvitations", new[] { "Team_TeamId" });
            DropIndex("dbo.TeamInvitations", new[] { "Language_LanguageId" });
            DropIndex("dbo.TeamInvitations", new[] { "GamerOffer_GamerOfferId" });
            DropIndex("dbo.Teams", new[] { "Logo_ImageId" });
            DropIndex("dbo.Teams", new[] { "Leader_GamerProfileId" });
            DropIndex("dbo.Teams", new[] { "AvgLeague_LeagueId" });
            DropIndex("dbo.Teams", new[] { "Name" });
            DropIndex("dbo.TeamOffers", new[] { "Team_TeamId" });
            DropIndex("dbo.TeamOffers", new[] { "RequiredMinLeague_LeagueId" });
            DropIndex("dbo.TeamOffers", new[] { "RequiredMaxLeague_LeagueId" });
            DropIndex("dbo.JoinRequests", new[] { "TeamOffer_TeamOfferId" });
            DropIndex("dbo.JoinRequests", new[] { "GamerProfile_GamerProfileId" });
            DropIndex("dbo.Leagues", new[] { "Logo_ImageId" });
            DropIndex("dbo.GamerProfiles", new[] { "SoloQLeague_LeagueId" });
            DropIndex("dbo.GamerProfiles", new[] { "SecondaryPosition_PositionId" });
            DropIndex("dbo.GamerProfiles", new[] { "Region_RegionId" });
            DropIndex("dbo.GamerProfiles", new[] { "PrimaryPosition_PositionId" });
            DropIndex("dbo.GamerProfiles", new[] { "Portrait_ImageId" });
            DropIndex("dbo.GamerProfiles", new[] { "Person_PersonId" });
            DropIndex("dbo.GamerProfiles", new[] { "League3_LeagueId" });
            DropIndex("dbo.GamerProfiles", new[] { "FlexLeague_LeagueId" });
            DropIndex("dbo.GamerProfiles", new[] { "ContactDetails_ContactId" });
            DropIndex("dbo.GamerOffers", new[] { "RequiredMinAvLeague_LeagueId" });
            DropIndex("dbo.GamerOffers", new[] { "RequiredMaxAvLeague_LeagueId" });
            DropIndex("dbo.GamerOffers", new[] { "GamerProfile_GamerProfileId" });
            DropIndex("dbo.Champions", new[] { "SmallImage_ImageId" });
            DropIndex("dbo.Champions", new[] { "Portrait_ImageId" });
            DropTable("dbo.TeamTypes");
            DropTable("dbo.TeamInvitations");
            DropTable("dbo.QueueTypes");
            DropTable("dbo.Languages");
            DropTable("dbo.Teams");
            DropTable("dbo.TeamOffers");
            DropTable("dbo.JoinRequests");
            DropTable("dbo.Regions");
            DropTable("dbo.Positions");
            DropTable("dbo.People");
            DropTable("dbo.Leagues");
            DropTable("dbo.GamerProfiles");
            DropTable("dbo.GamerOffers");
            DropTable("dbo.Contacts");
            DropTable("dbo.Images");
            DropTable("dbo.Champions");
        }
    }
}
