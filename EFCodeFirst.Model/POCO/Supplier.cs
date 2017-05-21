using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class Supplier
    {
        public Supplier ToPOCO()
        {
            return new Supplier()
            {
                Id = this.Id,
                Name = this.Name,
                LoginName = this.LoginName,
                LoginPwd = this.LoginPwd,
                SupplierState = this.SupplierState,
                SupplierType = this.SupplierType,
                UserName = this.UserName,
                Zipcode = this.Zipcode,
                Address = this.Address,
                BankDep = this.BankDep,
                BankNum = this.BankNum,
                CreateTime = this.CreateTime,
                Email = this.Email,
                IsBid = this.IsBid,
                IsDelete = this.IsDelete,
                Number = this.Number,
                PhoneNum = this.PhoneNum
            };
        }
    }
}
