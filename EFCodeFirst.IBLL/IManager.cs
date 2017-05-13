 
using EFCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.IBLL
{
	
	public partial interface IUserInfoBLL : IBaseBLL<UserInfo>
    {
       
    }   
	
	public partial interface IDepartmentBLL : IBaseBLL<Department>
    {
       
    }   
	
	public partial interface IRoleBLL : IBaseBLL<Role>
    {
       
    }   
	
	public partial interface IPermissionBLL : IBaseBLL<Permission>
    {
       
    }   
	
	public partial interface IUserVipPermissionBLL : IBaseBLL<UserVipPermission>
    {
       
    }   
	
	public partial interface IUserRoleBLL : IBaseBLL<UserRole>
    {
       
    }   
	
	public partial interface IRolePerBLL : IBaseBLL<RolePer>
    {
       
    }   
	
	public partial interface IBillTypeBLL : IBaseBLL<BillType>
    {
       
    }   
	
	public partial interface ISupplierBLL : IBaseBLL<Supplier>
    {
       
    }   
	
	public partial interface ITApplyBLL : IBaseBLL<TApply>
    {
       
    }   
	
	public partial interface ITapplyBillBLL : IBaseBLL<TapplyBill>
    {
       
    }   
	
	public partial interface ITapplySupplierBLL : IBaseBLL<TapplySupplier>
    {
       
    }   
	
}