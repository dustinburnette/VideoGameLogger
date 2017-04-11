namespace VideoGameLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreatedByToVideoGames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoGames", "CreatedBy", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VideoGames", "CreatedBy");
        }
    }
}
