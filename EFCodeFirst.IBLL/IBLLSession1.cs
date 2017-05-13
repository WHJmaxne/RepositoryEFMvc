 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.IBLL
{
	public partial interface IBLLSession
    {
	
		IUserInfoBLL UserInfoBLL{get;}
	
		IDepartmentBLL DepartmentBLL{get;}
	
		IRoleBLL RoleBLL{get;}
	
		IPermissionBLL PermissionBLL{get;}
	
		IUserVipPermissionBLL UserVipPermissionBLL{get;}
	
		IUserRoleBLL UserRoleBLL{get;}
	
		IRolePerBLL RolePerBLL{get;}
	
		IBillTypeBLL BillTypeBLL{get;}
	
		ISupplierBLL SupplierBLL{get;}
	
		ITApplyBLL TApplyBLL{get;}
	
		ITapplyBillBLL TapplyBillBLL{get;}
	
		ITapplySupplierBLL TapplySupplierBLL{get;}
	}	
}