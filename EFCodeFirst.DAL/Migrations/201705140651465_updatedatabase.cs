namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TapplyBills", "TApplyId", "dbo.TApplies");
            DropIndex("dbo.TapplyBills", new[] { "TApplyId" });
            AddColumn("dbo.TapplyBills", "TApplyNumber", c => c.String());
            DropColumn("dbo.TapplyBills", "TApplyId");
        }

        public override void Down()
        {
            AddColumn("dbo.TapplyBills", "TApplyId", c => c.Int(nullable: false));
            DropColumn("dbo.TapplyBills", "TApplyNumber");
            CreateIndex("dbo.TapplyBills", "TApplyId");
            AddForeignKey("dbo.TapplyBills", "TApplyId", "dbo.TApplies", "Id", cascadeDelete: true);
        }
    }
}
