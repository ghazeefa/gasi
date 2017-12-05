namespace DeadlineManagementDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filetype_updated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FileTypes", "ReviseagainMonths");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileTypes", "ReviseagainMonths", c => c.Int(nullable: false));
        }
    }
}
