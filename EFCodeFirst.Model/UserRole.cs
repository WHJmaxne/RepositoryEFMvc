using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public class UserRole
    {
        public int Id { get; set; }
        [DisplayName("用户")]
        public int UserInfoId { get; set; }
        [DisplayName("角色")]
        public int RoleId { get; set; }
        [DisplayName("是否删除")]
        public bool IsDel { get; set; }
        [DisplayName("添加时间")]
        public DateTime AddTime { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual Role Role { get; set; }
    }
}
