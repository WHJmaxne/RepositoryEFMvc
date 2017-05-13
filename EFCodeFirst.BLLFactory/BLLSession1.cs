
using EFCodeFirst.IBLL;
using EFCodeFirst.BLL;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks; 

namespace EFCodeFirst.BLLFactory
{
	public partial class BLLSession : IBLLSession
    {
	
		private IUserInfoBLL _UserInfoBLL;
        public IUserInfoBLL UserInfoBLL
        {
            get
            {
                if(_UserInfoBLL == null)
                {
				    _UserInfoBLL =new UserInfoBLL();
                }
                return _UserInfoBLL;
            }
        }
	
		private IDepartmentBLL _DepartmentBLL;
        public IDepartmentBLL DepartmentBLL
        {
            get
            {
                if(_DepartmentBLL == null)
                {
				    _DepartmentBLL =new DepartmentBLL();
                }
                return _DepartmentBLL;
            }
        }
	
		private IRoleBLL _RoleBLL;
        public IRoleBLL RoleBLL
        {
            get
            {
                if(_RoleBLL == null)
                {
				    _RoleBLL =new RoleBLL();
                }
                return _RoleBLL;
            }
        }
	
		private IPermissionBLL _PermissionBLL;
        public IPermissionBLL PermissionBLL
        {
            get
            {
                if(_PermissionBLL == null)
                {
				    _PermissionBLL =new PermissionBLL();
                }
                return _PermissionBLL;
            }
        }
	
		private IUserVipPermissionBLL _UserVipPermissionBLL;
        public IUserVipPermissionBLL UserVipPermissionBLL
        {
            get
            {
                if(_UserVipPermissionBLL == null)
                {
				    _UserVipPermissionBLL =new UserVipPermissionBLL();
                }
                return _UserVipPermissionBLL;
            }
        }
	
		private IUserRoleBLL _UserRoleBLL;
        public IUserRoleBLL UserRoleBLL
        {
            get
            {
                if(_UserRoleBLL == null)
                {
				    _UserRoleBLL =new UserRoleBLL();
                }
                return _UserRoleBLL;
            }
        }
	
		private IRolePerBLL _RolePerBLL;
        public IRolePerBLL RolePerBLL
        {
            get
            {
                if(_RolePerBLL == null)
                {
				    _RolePerBLL =new RolePerBLL();
                }
                return _RolePerBLL;
            }
        }
	
		private IBillTypeBLL _BillTypeBLL;
        public IBillTypeBLL BillTypeBLL
        {
            get
            {
                if(_BillTypeBLL == null)
                {
				    _BillTypeBLL =new BillTypeBLL();
                }
                return _BillTypeBLL;
            }
        }
	
		private ISupplierBLL _SupplierBLL;
        public ISupplierBLL SupplierBLL
        {
            get
            {
                if(_SupplierBLL == null)
                {
				    _SupplierBLL =new SupplierBLL();
                }
                return _SupplierBLL;
            }
        }
	
		private ITApplyBLL _TApplyBLL;
        public ITApplyBLL TApplyBLL
        {
            get
            {
                if(_TApplyBLL == null)
                {
				    _TApplyBLL =new TApplyBLL();
                }
                return _TApplyBLL;
            }
        }
	
		private ITapplyBillBLL _TapplyBillBLL;
        public ITapplyBillBLL TapplyBillBLL
        {
            get
            {
                if(_TapplyBillBLL == null)
                {
				    _TapplyBillBLL =new TapplyBillBLL();
                }
                return _TapplyBillBLL;
            }
        }
	
		private ITapplySupplierBLL _TapplySupplierBLL;
        public ITapplySupplierBLL TapplySupplierBLL
        {
            get
            {
                if(_TapplySupplierBLL == null)
                {
				    _TapplySupplierBLL =new TapplySupplierBLL();
                }
                return _TapplySupplierBLL;
            }
        }
	}	
}