 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks; 

namespace EFCodeFirst.IDAL
{
		
	public partial interface IUserInfoDAL :IBaseDAL<Model.UserInfo>
    {
	 
    }
		
	public partial interface IDepartmentDAL :IBaseDAL<Model.Department>
    {
	 
    }
		
	public partial interface IRoleDAL :IBaseDAL<Model.Role>
    {
	 
    }
		
	public partial interface IPermissionDAL :IBaseDAL<Model.Permission>
    {
	 
    }
		
	public partial interface IUserVipPermissionDAL :IBaseDAL<Model.UserVipPermission>
    {
	 
    }
		
	public partial interface IUserRoleDAL :IBaseDAL<Model.UserRole>
    {
	 
    }
		
	public partial interface IRolePerDAL :IBaseDAL<Model.RolePer>
    {
	 
    }
	
}