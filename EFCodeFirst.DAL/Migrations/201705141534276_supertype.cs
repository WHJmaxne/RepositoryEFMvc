namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supertype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suppliers", "SupplierType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "SupplierType", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
