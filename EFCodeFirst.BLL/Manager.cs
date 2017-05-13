 
using EFCodeFirst.IBLL;
using EFCodeFirst.Model; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace EFCodeFirst.BLL
{
	
	public partial class UserInfoBLL :BaseBLL<UserInfo>,IUserInfoBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.UserInfoDAL;
        }
    }   
	
	public partial class DepartmentBLL :BaseBLL<Department>,IDepartmentBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.DepartmentDAL;
        }
    }   
	
	public partial class RoleBLL :BaseBLL<Role>,IRoleBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.RoleDAL;
        }
    }   
	
	public partial class PermissionBLL :BaseBLL<Permission>,IPermissionBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.PermissionDAL;
        }
    }   
	
	public partial class UserVipPermissionBLL :BaseBLL<UserVipPermission>,IUserVipPermissionBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.UserVipPermissionDAL;
        }
    }   
	
	public partial class UserRoleBLL :BaseBLL<UserRole>,IUserRoleBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.UserRoleDAL;
        }
    }   
	
	public partial class RolePerBLL :BaseBLL<RolePer>,IRolePerBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.RolePerDAL;
        }
    }   
	
	public partial class BillTypeBLL :BaseBLL<BillType>,IBillTypeBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.BillTypeDAL;
        }
    }   
	
	public partial class SupplierBLL :BaseBLL<Supplier>,ISupplierBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.SupplierDAL;
        }
    }   
	
	public partial class TApplyBLL :BaseBLL<TApply>,ITApplyBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.TApplyDAL;
        }
    }   
	
	public partial class TapplyBillBLL :BaseBLL<TapplyBill>,ITapplyBillBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.TapplyBillDAL;
        }
    }   
	
	public partial class TapplySupplierBLL :BaseBLL<TapplySupplier>,ITapplySupplierBLL
    {
        public override void SetCurrent()
        {
            CurrentDAL = this.DbSession.TapplySupplierDAL;
        }
    }   
	
}