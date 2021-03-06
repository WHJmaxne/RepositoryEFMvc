﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class Role
    {
        public Role()
        {
            this.UserRole = new HashSet<UserRole>();
            this.RolePer = new HashSet<RolePer>();
            this.TApply = new HashSet<TApply>();
        }
        public int Id { get; set; }
        [DisplayName("部门"), ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [Required, MaxLength(50), DisplayName("角色名称")]
        public string RoleName { get; set; }
        [DisplayName("备注")]
        public string RoleRemark { get; set; }
        [DisplayName("是否显示")]
        public bool RoleIsShow { get; set; }
        [DisplayName("是否删除")]
        public bool RoleIsDel { get; set; }
        [DisplayName("添加时间")]
        public System.DateTime RoleAddTime { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<RolePer> RolePer { get; set; }
        public virtual ICollection<TApply> TApply { get; set; }
    }
}
