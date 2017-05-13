using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Model
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.UserRole = new HashSet<UserRole>();
            this.UserVipPermission = new HashSet<UserVipPermission>();
            this.TApply = new HashSet<TApply>();
        }
        public int Id { get; set; }

        [DisplayName("部门")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "用户名不能为空！"), DisplayName("用户名"), MaxLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空！"), DisplayName("密码"), MaxLength(50)]
        public string UserPwd { get; set; }
        [DisplayName("真实姓名"), MaxLength(50)]
        public string RealName { get; set; }
        [DisplayName("电话号码"), MaxLength(50)]
        public string UserTelephone { get; set; }
        [DisplayName("电子邮箱"), MaxLength(50)]
        public string UserEmail { get; set; }
        [Required, DisplayName("是否锁定")]
        public bool UserIsLock { get; set; }
        [Required, DisplayName("添加时间")]
        public System.DateTime UserAddTime { get; set; }
        [Required, DisplayName("是否删除")]
        public bool UserIsDel { get; set; }
        [DisplayName("备注")]
        public string UserRemark { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<UserVipPermission> UserVipPermission { get; set; }
        public virtual ICollection<TApply> TApply { get; set; }
    }
}
