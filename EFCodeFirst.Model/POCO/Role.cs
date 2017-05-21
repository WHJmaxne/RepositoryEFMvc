using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class Role
    {
        public Role ToPOCO()
        {
            return new Role()
            {
                Id = this.Id,
                RoleName = this.RoleName,
                RoleAddTime = this.RoleAddTime,
                RoleIsDel = this.RoleIsDel,
                RoleIsShow = this.RoleIsShow,
                RoleRemark = this.RoleRemark,
                DepartmentId = this.DepartmentId
            };
        }
    }
}
