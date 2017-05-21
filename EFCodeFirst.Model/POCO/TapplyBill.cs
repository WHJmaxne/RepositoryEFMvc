using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class TapplyBill
    {
        public TapplyBill ToPOCO()
        {
            return new TapplyBill()
            {
                Id = this.Id,
                BillName = this.BillName,
                BillSpec = this.BillSpec,
                BillMata = this.BillMata,
                BillNum = this.BillNum,
                BillRemark = this.BillRemark,
                CreateTime = this.CreateTime,
                BillTypeId = this.BillTypeId,
                DeliveryDate = this.DeliveryDate,
                TApplyNumber = this.TApplyNumber,
                Price = this.Price,
                Unit = this.Unit,
                IsDelete = this.IsDelete
            };
        }
    }
}
