namespace VideoGameLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterID = c.Int(nullable: false, identity: true),
                        CharacterName = c.String(),
                    })
                .PrimaryKey(t => t.CharacterID);
            
            CreateTable(
                "dbo.VideoGames",
                c => new
                    {
                        VideoGameID = c.Int(nullable: false, identity: true),
                        NameOfFightingGame = c.String(),
                        WinOrLose = c.Boolean(nullable: false),
                        NumberOfRounds = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                        HowLongMinutes = c.Time(nullable: false, precision: 7),
                        RecordTimeMinutes = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.VideoGameID)
                .ForeignKey("dbo.Characters", t => t.CharacterID, cascadeDelete: true)
                .Index(t => t.CharacterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoGames", "CharacterID", "dbo.Characters");
            DropIndex("dbo.VideoGames", new[] { "CharacterID" });
            DropTable("dbo.VideoGames");
            DropTable("dbo.Characters");
        }
    }
}
