using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public class Supplier
    {
        public Supplier()
        {
            TapplySuppliers = new HashSet<TapplySupplier>();
        }
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        [Required, MaxLength(100)]
        public string Number { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        [Required, MaxLength(200)]
        public string Name { get; set; }
        /// <summary>
        /// 登录用户名
        /// </summary>
        [Required, MaxLength(50)]
        public string LoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [Required, MaxLength(50)]
        public string LoginPwd { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        /// <summary>
        /// 供应商状态:
        /// 1:已注册
        /// 2:已上传资质文件
        /// 3:已通过
        /// </summary>
        public int SupplierState { get; set; }
        /// <summary>
        /// 是否允许投标
        /// </summary>
        public bool IsBid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 企业类型
        /// </summary>
        [Required, MaxLength(50)]
        public string SupplierType { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string Zipcode { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string BankDep { get; set; }
        /// <summary>
        /// 银行账户
        /// </summary>
        public string BankNum { get; set; }
        public virtual ICollection<TapplySupplier> TapplySuppliers { get; set; }
    }
}
