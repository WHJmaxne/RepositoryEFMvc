namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class edituserinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRoles", "IsDel", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserRoles", "AddTime", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.UserRoles", "AddTime");
            DropColumn("dbo.UserRoles", "IsDel");
        }
    }
}
