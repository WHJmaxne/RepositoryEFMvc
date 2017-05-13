using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class UserInfo
    {
        public UserInfo ToPOCO()
        {
            return new UserInfo()
            {
                Id = this.Id,
                UserName = this.UserName,
                RealName = this.RealName,
                UserEmail = this.UserEmail,
                UserTelephone = this.UserTelephone,
                UserRemark = this.UserRemark,
                UserAddTime = this.UserAddTime,
                UserIsDel = this.UserIsDel,
                DepartmentId = this.DepartmentId,
                UserIsLock = this.UserIsLock,
                UserPwd = this.UserPwd,
                Department = this.Department.ToPOCO()
            };
        }
    }
}
