namespace VideoGameLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedLoginCharacters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "CreatedBy", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "CreatedBy");
        }
    }
}
