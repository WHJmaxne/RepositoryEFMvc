using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
   public class RolePer
    {
       public int Id { get; set; }
       [DisplayName("角色")]
       public int RoleId { get; set; }
       [DisplayName("权限")]
       public int PermissionId { get; set; }
       [DisplayName("添加时间")]
       public DateTime AddTime { get; set; }

       public virtual Role Role { get; set; }
       public virtual Permission Permission { get; set; }
    }
}
