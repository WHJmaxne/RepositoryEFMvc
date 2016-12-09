namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepParentId = c.Int(nullable: false),
                        DepName = c.String(),
                        DepRemark = c.String(),
                        DepIsdel = c.Boolean(nullable: false),
                        DepAddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        RoleName = c.String(),
                        RoleRemark = c.String(),
                        RoleIsshow = c.Boolean(nullable: false),
                        RoleIsdel = c.Boolean(nullable: false),
                        RoleAddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.RolePers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                        AddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissions", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.PermissionId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        PName = c.String(),
                        PAreaName = c.String(),
                        PControllerName = c.String(),
                        PActionName = c.String(),
                        PFormmethod = c.Int(nullable: false),
                        POperationType = c.Int(nullable: false),
                        PIco = c.String(),
                        POrder = c.Int(nullable: false),
                        PIsLink = c.Boolean(nullable: false),
                        PLinkUrl = c.String(),
                        PIsShow = c.Boolean(nullable: false),
                        PRemark = c.String(),
                        PIsDel = c.Boolean(nullable: false),
                        PAddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserVipPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserInfoId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                        VipRemark = c.String(),
                        VipIsDel = c.Boolean(nullable: false),
                        VipAddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissions", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfoId, cascadeDelete: true)
                .Index(t => t.PermissionId)
                .Index(t => t.UserInfoId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        UserPwd = c.String(nullable: false, maxLength: 50),
                        RealName = c.String(maxLength: 50),
                        UserTelephone = c.String(maxLength: 50),
                        UserEmail = c.String(maxLength: 50),
                        UserIsLock = c.Boolean(nullable: false),
                        UserAddTime = c.DateTime(nullable: false),
                        UserIsDel = c.Boolean(nullable: false),
                        UserRemark = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserInfoId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfoId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolePers", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserVipPermissions", "UserInfoId", "dbo.UserInfoes");
            DropForeignKey("dbo.UserRoles", "UserInfoId", "dbo.UserInfoes");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserInfoes", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.UserVipPermissions", "PermissionId", "dbo.Permissions");
            DropForeignKey("dbo.RolePers", "PermissionId", "dbo.Permissions");
            DropForeignKey("dbo.Roles", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.RolePers", new[] { "RoleId" });
            DropIndex("dbo.UserVipPermissions", new[] { "UserInfoId" });
            DropIndex("dbo.UserRoles", new[] { "UserInfoId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserInfoes", new[] { "DepartmentId" });
            DropIndex("dbo.UserVipPermissions", new[] { "PermissionId" });
            DropIndex("dbo.RolePers", new[] { "PermissionId" });
            DropIndex("dbo.Roles", new[] { "DepartmentId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.UserVipPermissions");
            DropTable("dbo.Permissions");
            DropTable("dbo.RolePers");
            DropTable("dbo.Roles");
            DropTable("dbo.Departments");
        }
    }
}
