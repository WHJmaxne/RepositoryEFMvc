using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class TapplyBill
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 招标委托编号
        /// </summary>
        [Required, DisplayName("招标委托编号")]
        public string TApplyNumber { get; set; }
        /// <summary>
        /// 物料类别id
        /// </summary>
        [DisplayName("物料类别")]
        [ForeignKey("BillType")]
        public int BillTypeId { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        [Required, MaxLength(50), DisplayName("物料名称")]
        public string BillName { get; set; }
        /// <summary>
        /// 物料规格
        /// </summary>
        [Required, MaxLength(50), DisplayName("物料规格")]
        public string BillSpec { get; set; }
        /// <summary>
        /// 物料材质
        /// </summary>
        [DisplayName("物料材质")]
        public string BillMata { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [DisplayName("单位"), Required]
        public string Unit { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [DisplayName("数量")]
        public int BillNum { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [DisplayName("单价")]
        public decimal Price { get; set; }
        /// <summary>
        /// 交货日期
        /// </summary>
        [Required, DisplayName("交货日期")]
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
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

        public virtual BillType BillType { get; set; }
    }
}
