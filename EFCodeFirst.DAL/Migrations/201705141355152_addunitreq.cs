namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addunitreq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TapplyBills", "Unit", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TapplyBills", "Unit", c => c.String());
        }
    }
}
