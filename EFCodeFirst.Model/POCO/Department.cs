using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class Department
    {
        public Department ToPOCO()
        {
            return new Department()
            {
                Id = this.Id,
                DepAddTime = this.DepAddTime,
                DepIsdel = this.DepIsdel,
                DepName = this.DepName,
                DepParentId = this.DepParentId,
                DepRemark = this.DepRemark
            };
        }
    }
}
