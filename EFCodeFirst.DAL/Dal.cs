using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirst.IDAL;
using EFCodeFirst.Model;

namespace EFCodeFirst.DAL
{

    public partial class UserInfoDAL : BaseDAL<Model.UserInfo>, IDAL.IUserInfoDAL
    {
    }

    public partial class DepartmentDAL : BaseDAL<Model.Department>, IDAL.IDepartmentDAL
    {

    }

    public partial class RoleDAL : BaseDAL<Model.Role>, IDAL.IRoleDAL
    {

    }

    public partial class PermissionDAL : BaseDAL<Model.Permission>, IDAL.IPermissionDAL
    {

    }

    public partial class UserVipPermissionDAL : BaseDAL<Model.UserVipPermission>, IDAL.IUserVipPermissionDAL
    {

    }

    public partial class UserRoleDAL : BaseDAL<Model.UserRole>, IDAL.IUserRoleDAL
    {

    }

    public partial class RolePerDAL : BaseDAL<Model.RolePer>, IDAL.IRolePerDAL
    {

    }

    public partial class BillTypeDAL : BaseDAL<Model.BillType>, IDAL.IBillTypeDAL
    {

    }

    public partial class SupplierDAL : BaseDAL<Model.Supplier>, IDAL.ISupplierDAL
    {

    }

    public partial class TApplyDAL : BaseDAL<Model.TApply>, IDAL.ITApplyDAL
    {

    }

    public partial class TapplyBillDAL : BaseDAL<Model.TapplyBill>, IDAL.ITapplyBillDAL
    {

    }

    public partial class TapplySupplierDAL : BaseDAL<Model.TapplySupplier>, IDAL.ITapplySupplierDAL
    {

    }

}