using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class BillType
    {
        public BillType()
        {
            TApplys = new HashSet<TApply>();
            TapplyBills = new HashSet<TapplyBill>();
        }
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 自关联父Id 
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 物料类型名称
        /// </summary>
        [Required, MaxLength(100)]
        public string BillTypeName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        public virtual ICollection<TApply> TApplys { get; set; }
        public virtual ICollection<TapplyBill> TapplyBills { get; set; }
    }
}
