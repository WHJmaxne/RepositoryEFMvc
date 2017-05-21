namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUnit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TapplyBills", "Unit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TapplyBills", "Unit");
        }
    }
}
