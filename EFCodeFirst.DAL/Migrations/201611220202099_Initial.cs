namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Permissions", "PName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Permissions", "PAreaName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Permissions", "PControllerName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Permissions", "PActionName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Permissions", "PIco", c => c.String(maxLength: 200));
            AlterColumn("dbo.Permissions", "PLinkUrl", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Permissions", "PLinkUrl", c => c.String());
            AlterColumn("dbo.Permissions", "PIco", c => c.String());
            AlterColumn("dbo.Permissions", "PActionName", c => c.String());
            AlterColumn("dbo.Permissions", "PControllerName", c => c.String());
            AlterColumn("dbo.Permissions", "PAreaName", c => c.String());
            AlterColumn("dbo.Permissions", "PName", c => c.String());
        }
    }
}
