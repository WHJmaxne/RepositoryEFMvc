using EFCodeFirst.DAL;
using EFCodeFirst.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DALFactory
{
    public partial class DBSession:IDBSession
    {
        DbContext db = DbEFContextFactory.CreatDbContext();
        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }

        //private IUserInfoDAL _UserInfoDAL;
        //public IUserInfoDAL UserInfoDAL
        //{
        //    get
        //    {
        //        if (_UserInfoDAL == null)
        //        {
        //            _UserInfoDAL = AbstractFactory.CreatUserInfo();
        //        }
        //        return _UserInfoDAL;
        //    }
        //}

        //private IDepartmentDAL _DepartmentDAL;
        //public IDepartmentDAL DepartmentDAL
        //{
        //    get
        //    {
        //        if (_DepartmentDAL==null)
        //        {
        //            _DepartmentDAL = AbstractFactory.CreatDepartment();
        //        }
        //        return _DepartmentDAL;
        //    }
        //}
    }
}
