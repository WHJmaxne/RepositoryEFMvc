namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit20161122 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Roles", "RoleIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Roles", "RoleIsDel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "RoleIsDel", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Roles", "RoleIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
        }
    }
}
