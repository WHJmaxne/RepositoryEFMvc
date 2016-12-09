using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
   public class Department
    {
       public Department()
       {
           this.UserInfo = new HashSet<UserInfo>();
           this.Role = new HashSet<Role>();
       }
        public int Id { get; set; }
        public int DepParentId { get; set; }
        public string DepName { get; set; }
        public string DepRemark { get; set; }
        public bool DepIsdel { get; set; }
        public System.DateTime DepAddTime { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }
        public virtual ICollection<Role> Role { get; set; }
    }
}
