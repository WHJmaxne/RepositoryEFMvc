using EFCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DAL
{
    public class DbEFContext : DbContext
    {
        public DbEFContext()
            : base("EFContext")
        {

        }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<RolePer> RolePers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserVipPermission> UserVipPermissions { get; set; }
        public DbSet<TApply> TApplys { get; set; }
        public DbSet<TapplyBill> TapplyBills { get; set; }
        public DbSet<BillType> BillTypes { get; set; }
        public DbSet<TapplySupplier> TapplySuppliers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasRequired(u => u.Department)
                .WithMany(d => d.UserInfo)
                .HasForeignKey(f => f.DepartmentId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UserInfo>().HasRequired(u => u.Department)
               .WithMany(d => d.UserInfo)
               .HasForeignKey(f => f.DepartmentId)
               .WillCascadeOnDelete(false);
        }
    }
}
