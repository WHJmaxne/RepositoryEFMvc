﻿
using EFCodeFirst.DAL;
using EFCodeFirst.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq; 
using System.Text;
using System.Threading.Tasks; 

namespace EFCodeFirst.DALFactory
{
	public partial class DBSession : IDBSession
    {
	
		private IUserInfoDAL _UserInfoDAL;
        public IUserInfoDAL UserInfoDAL
        {
            get
            {
                if(_UserInfoDAL == null)
                {
				    _UserInfoDAL =AbstractFactory.CreateUserInfoDAL();
                }
                return _UserInfoDAL;
            }
        }
	
		private IDepartmentDAL _DepartmentDAL;
        public IDepartmentDAL DepartmentDAL
        {
            get
            {
                if(_DepartmentDAL == null)
                {
				    _DepartmentDAL =AbstractFactory.CreateDepartmentDAL();
                }
                return _DepartmentDAL;
            }
        }
	
		private IRoleDAL _RoleDAL;
        public IRoleDAL RoleDAL
        {
            get
            {
                if(_RoleDAL == null)
                {
				    _RoleDAL =AbstractFactory.CreateRoleDAL();
                }
                return _RoleDAL;
            }
        }
	
		private IPermissionDAL _PermissionDAL;
        public IPermissionDAL PermissionDAL
        {
            get
            {
                if(_PermissionDAL == null)
                {
				    _PermissionDAL =AbstractFactory.CreatePermissionDAL();
                }
                return _PermissionDAL;
            }
        }
	
		private IUserVipPermissionDAL _UserVipPermissionDAL;
        public IUserVipPermissionDAL UserVipPermissionDAL
        {
            get
            {
                if(_UserVipPermissionDAL == null)
                {
				    _UserVipPermissionDAL =AbstractFactory.CreateUserVipPermissionDAL();
                }
                return _UserVipPermissionDAL;
            }
        }
	
		private IUserRoleDAL _UserRoleDAL;
        public IUserRoleDAL UserRoleDAL
        {
            get
            {
                if(_UserRoleDAL == null)
                {
				    _UserRoleDAL =AbstractFactory.CreateUserRoleDAL();
                }
                return _UserRoleDAL;
            }
        }
	
		private IRolePerDAL _RolePerDAL;
        public IRolePerDAL RolePerDAL
        {
            get
            {
                if(_RolePerDAL == null)
                {
				    _RolePerDAL =AbstractFactory.CreateRolePerDAL();
                }
                return _RolePerDAL;
            }
        }
	
		private IBillTypeDAL _BillTypeDAL;
        public IBillTypeDAL BillTypeDAL
        {
            get
            {
                if(_BillTypeDAL == null)
                {
				    _BillTypeDAL =AbstractFactory.CreateBillTypeDAL();
                }
                return _BillTypeDAL;
            }
        }
	
		private ISupplierDAL _SupplierDAL;
        public ISupplierDAL SupplierDAL
        {
            get
            {
                if(_SupplierDAL == null)
                {
				    _SupplierDAL =AbstractFactory.CreateSupplierDAL();
                }
                return _SupplierDAL;
            }
        }
	
		private ITApplyDAL _TApplyDAL;
        public ITApplyDAL TApplyDAL
        {
            get
            {
                if(_TApplyDAL == null)
                {
				    _TApplyDAL =AbstractFactory.CreateTApplyDAL();
                }
                return _TApplyDAL;
            }
        }
	
		private ITapplyBillDAL _TapplyBillDAL;
        public ITapplyBillDAL TapplyBillDAL
        {
            get
            {
                if(_TapplyBillDAL == null)
                {
				    _TapplyBillDAL =AbstractFactory.CreateTapplyBillDAL();
                }
                return _TapplyBillDAL;
            }
        }
	
		private ITapplySupplierDAL _TapplySupplierDAL;
        public ITapplySupplierDAL TapplySupplierDAL
        {
            get
            {
                if(_TapplySupplierDAL == null)
                {
				    _TapplySupplierDAL =AbstractFactory.CreateTapplySupplierDAL();
                }
                return _TapplySupplierDAL;
            }
        }
	}	
}