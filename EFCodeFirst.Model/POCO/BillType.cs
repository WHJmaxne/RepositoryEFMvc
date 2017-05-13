using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class BillType
    {
        public BillType ToPOCO()
        {
            return new BillType()
            {
                Id = this.Id,
                BillTypeName = this.BillTypeName,
                CreateTime = this.CreateTime,
                ParentId = this.ParentId,
                IsDelete = this.IsDelete
            };
        }
    }
}
