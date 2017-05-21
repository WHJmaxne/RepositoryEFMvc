namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tapplybilldisplayname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TapplyBills", "TApplyNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TapplyBills", "TApplyNumber", c => c.String());
        }
    }
}
