using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public class TapplyBill
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 招标委托Id
        /// </summary>
        [ForeignKey("TApply")]
        public int TApplyId { get; set; }
        /// <summary>
        /// 物料类别id
        /// </summary>
        [ForeignKey("BillType")]
        public int BillTypeId { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        [Required, MaxLength(50)]
        public string BillName { get; set; }
        /// <summary>
        /// 物料规格
        /// </summary>
        [Required, MaxLength(50)]
        public string BillSpec { get; set; }
        /// <summary>
        /// 物料材质
        /// </summary>
        public string BillMata { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int BillNum { get; set; }
        /// <summary>
        /// 交货日期
        /// </summary>
        [Required]
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BillRemark { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }

        public virtual TApply TApply { get; set; }
        public virtual BillType BillType { get; set; }
    }
}
