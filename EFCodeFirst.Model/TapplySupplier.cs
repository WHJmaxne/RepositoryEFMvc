using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public class TapplySupplier
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        [ForeignKey("TApply")]
        public int TApplyId { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual TApply TApply { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
