namespace VideoGameLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameOFFigthingGameNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VideoGames", "NameOfFightingGame", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VideoGames", "NameOfFightingGame", c => c.String());
        }
    }
}
