using EFCodeFirst.Model.ExtensionModel;
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
    public partial class TApply
    {
        public TApply()
        {
            TapplySuppliers = new HashSet<TapplySupplier>();
        }
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 委托编号
        /// </summary>
        [Required, MaxLength(50), DisplayName("委托编号")]
        public string ApplyId { get; set; }
        /// <summary>
        /// 委托名称
        /// </summary>
        [Required, MaxLength(200), DisplayName("委托名称")]
        public string ApplyName { get; set; }
        /// <summary>
        /// 采购类别
        /// </summary>
        [ForeignKey("BillType"), DisplayName("采购类别")]
        public int BillTypeId { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [DisplayName("经办人")]
        public int ApplyUser { get; set; }
        /// <summary>
        /// 计划类型
        /// </summary>
        [DisplayName("计划类型")]
        public PlanType PlanType { get; set; }
        /// <summary>
        /// 委托状态
        /// </summary>
        [DisplayName("委托状态")]
        public ApplyState ApplyState { get; set; }
        /// <summary>
        /// 预算金额
        /// </summary>
        [DisplayName("预算金额")]
        public decimal ApplySum { get; set; }
        /// <summary>
        /// 招标方式
        /// </summary>
        [DisplayName("招标方式")]
        public ProjectType ProjectType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string ApplyRemark { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        [DisplayName("审核人员")]
        public int ExaminationUser { get; set; }
        /// <summary>
        /// 项目经理
        /// </summary>
        [DisplayName("项目经理")]
        public int? ProjectManager { get; set; }
        /// <summary>
        /// 是否被删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDelete { get; set; }
        /// <summary>
        /// 创建计划时间
        /// </summary>
        [DisplayName("创建计划时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 复核通过时间
        /// </summary>
        [DisplayName("复核通过时间")]
        public DateTime? ReviewTime { get; set; }
        /// <summary>
        /// 公告发布时间
        /// </summary>
        [DisplayName("发布公告时间")]
        public DateTime? NoticeTime { get; set; }
        /// <summary>
        /// 指派完成时间
        /// </summary>
        [DisplayName("指派完成时间")]
        public DateTime? AssignTime { get; set; }
        [NotMapped]
        public string CompanyIds { get; set; }

        /// <summary>
        /// 项目经理
        /// </summary>
        [ForeignKey("ProjectManager")]
        public virtual UserInfo UserInfo { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [ForeignKey("ApplyUser")]
        public virtual UserInfo UserInfo1 { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        [ForeignKey("ExaminationUser")]
        public virtual Role Role { get; set; }
        public virtual BillType BillType { get; set; }
        public virtual ICollection<TapplySupplier> TapplySuppliers { get; set; }
    }
}
