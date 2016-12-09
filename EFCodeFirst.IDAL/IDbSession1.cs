 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.IDAL
{
	public partial interface IDBSession
    {
	
		IUserInfoDAL UserInfoDAL{get;}
	
		IDepartmentDAL DepartmentDAL{get;}
	
		IRoleDAL RoleDAL{get;}
	
		IPermissionDAL PermissionDAL{get;}
	
		IUserVipPermissionDAL UserVipPermissionDAL{get;}
	
		IUserRoleDAL UserRoleDAL{get;}
	
		IRolePerDAL RolePerDAL{get;}
	}	
}