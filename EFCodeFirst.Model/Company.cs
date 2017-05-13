using EFCodeFirst.Model.ExtensionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string UserName { get; set; }
        public CompanyState CompanyState { get; set; }

    }
}
