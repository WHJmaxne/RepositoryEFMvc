using EFCodeFirst.BLL;
using EFCodeFirst.DALFactory;
using EFCodeFirst.IBLL;
using EFCodeFirst.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.BLLFactory
{
   public partial class BLLSession:IBLLSession
    {
       //private IUserInfoBLL _UserInfoBLL;
       // public IUserInfoBLL UserInfoBLL
       // {
       //     get
       //     {
       //         if (_UserInfoBLL == null)
       //         {
       //             _UserInfoBLL = new UserInfoBLL();
       //         }
       //         return _UserInfoBLL;
       //     }
       // }

        public bool SaveChanges()
        {
            IDBSession DbSession = DbSessionFactory.CreatDbSession();
            return DbSession.SaveChanges();
        }

        //private IDepartmentBLL _DepartmentBLL;
        //public IDepartmentBLL DepartmentBLL
        //{
        //    get
        //    {
        //        if (_DepartmentBLL==null)
        //        {
        //            _DepartmentBLL = new DepartmentBLL();
        //        }
        //        return _DepartmentBLL;
        //    }
        //}
    }
}
