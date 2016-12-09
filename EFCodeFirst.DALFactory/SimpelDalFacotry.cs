using EFCodeFirst.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq; 
using System.Reflection;
using System.Text;
using System.Threading.Tasks; 

namespace EFCodeFirst.DALFactory
{
    public partial class AbstractFactory
    {
		
	    public static IUserInfoDAL CreateUserInfoDAL()
        {
            string classFulleName = AssNameSpace + ".UserInfoDAL";
            return CreateInstance(classFulleName) as IUserInfoDAL;
        }
		
	    public static IDepartmentDAL CreateDepartmentDAL()
        {
            string classFulleName = AssNameSpace + ".DepartmentDAL";
            return CreateInstance(classFulleName) as IDepartmentDAL;
        }
		
	    public static IRoleDAL CreateRoleDAL()
        {
            string classFulleName = AssNameSpace + ".RoleDAL";
            return CreateInstance(classFulleName) as IRoleDAL;
        }
		
	    public static IPermissionDAL CreatePermissionDAL()
        {
            string classFulleName = AssNameSpace + ".PermissionDAL";
            return CreateInstance(classFulleName) as IPermissionDAL;
        }
		
	    public static IUserVipPermissionDAL CreateUserVipPermissionDAL()
        {
            string classFulleName = AssNameSpace + ".UserVipPermissionDAL";
            return CreateInstance(classFulleName) as IUserVipPermissionDAL;
        }
		
	    public static IUserRoleDAL CreateUserRoleDAL()
        {
            string classFulleName = AssNameSpace + ".UserRoleDAL";
            return CreateInstance(classFulleName) as IUserRoleDAL;
        }
		
	    public static IRolePerDAL CreateRolePerDAL()
        {
            string classFulleName = AssNameSpace + ".RolePerDAL";
            return CreateInstance(classFulleName) as IRolePerDAL;
        }
	}
	
}