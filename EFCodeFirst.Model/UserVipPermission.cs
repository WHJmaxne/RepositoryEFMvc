using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
   public class UserVipPermission
    {
        public int Id { get; set; }
       [DisplayName("用户")]
        public int UserInfoId { get; set; }
       [DisplayName("权限")]
        public int PermissionId { get; set; }
       [DisplayName("备注")]
        public string VipRemark { get; set; }
       [DisplayName("是否删除")]
        public bool VipIsDel { get; set; }
       [DisplayName("添加时间")]
        public System.DateTime VipAddTime { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
