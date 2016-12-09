using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.IBLL
{
   public partial interface IBLLSession
    {
       bool SaveChanges();
       //IUserInfoBLL UserInfoBLL { get; }
       //IDepartmentBLL DepartmentBLL { get; }
    }
}
