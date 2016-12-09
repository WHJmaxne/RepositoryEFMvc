 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks; 

namespace EFCodeFirst.DAL
{
		
	public partial class UserInfoDAL :BaseDAL<Model.UserInfo>,IDAL.IUserInfoDAL
    {
	 
    }
		
	public partial class DepartmentDAL :BaseDAL<Model.Department>,IDAL.IDepartmentDAL
    {
	 
    }
		
	public partial class RoleDAL :BaseDAL<Model.Role>,IDAL.IRoleDAL
    {
	 
    }
		
	public partial class PermissionDAL :BaseDAL<Model.Permission>,IDAL.IPermissionDAL
    {
	 
    }
		
	public partial class UserVipPermissionDAL :BaseDAL<Model.UserVipPermission>,IDAL.IUserVipPermissionDAL
    {
	 
    }
		
	public partial class UserRoleDAL :BaseDAL<Model.UserRole>,IDAL.IUserRoleDAL
    {
	 
    }
		
	public partial class RolePerDAL :BaseDAL<Model.RolePer>,IDAL.IRolePerDAL
    {
	 
    }
	
}