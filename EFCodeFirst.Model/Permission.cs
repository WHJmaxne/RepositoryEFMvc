using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class Permission
    {
        public Permission()
        {
            this.RolePer = new HashSet<RolePer>();
            this.UserVipPermission = new HashSet<UserVipPermission>();
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        [Required, MaxLength(50)]
        public string PName { get; set; }
        [MaxLength(50)]
        public string PAreaName { get; set; }
        [MaxLength(50)]
        public string PControllerName { get; set; }
        [MaxLength(50)]
        public string PActionName { get; set; }
        public int PFormmethod { get; set; }
        public int POperationType { get; set; }
        [MaxLength(200)]
        public string PIco { get; set; }
        public int POrder { get; set; }
        public bool PIsLink { get; set; }
        [MaxLength(1000)]
        public string PLinkUrl { get; set; }
        public bool PIsShow { get; set; }
        public string PRemark { get; set; }
        public bool PIsDel { get; set; }
        public System.DateTime PAddTime { get; set; }

        public virtual ICollection<RolePer> RolePer { get; set; }
        public virtual ICollection<UserVipPermission> UserVipPermission { get; set; }
    }
}
