namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addroletapply : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TApplies", "ExaminationUser", "dbo.UserInfoes");
            DropIndex("dbo.TApplies", new[] { "ExaminationUser" });
            AlterColumn("dbo.TApplies", "ExaminationUser", c => c.Int(nullable: false));
            CreateIndex("dbo.TApplies", "ExaminationUser");
            AddForeignKey("dbo.TApplies", "ExaminationUser", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TApplies", "ExaminationUser", "dbo.Roles");
            DropIndex("dbo.TApplies", new[] { "ExaminationUser" });
            AlterColumn("dbo.TApplies", "ExaminationUser", c => c.Int());
            CreateIndex("dbo.TApplies", "ExaminationUser");
            AddForeignKey("dbo.TApplies", "ExaminationUser", "dbo.UserInfoes", "Id");
        }
    }
}
