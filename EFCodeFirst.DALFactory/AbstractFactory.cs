using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using EFCodeFirst.IDAL;

namespace EFCodeFirst.DALFactory
{
    public partial class AbstractFactory
    {
        private static string AssNameSpace = ConfigurationManager.AppSettings["AssNameSpace"].ToString();

        private static object CreateInstance(string fullNameSpace)
        {
            var ass = Assembly.Load(AssNameSpace);
            return ass.CreateInstance(fullNameSpace);
        }

        //public static IUserInfoDAL CreateUserInfoDAL()
        //{
        //    string fullNameSpace = AssNameSpace + ".UserInfoDAL";
        //    return CreateInstance(fullNameSpace) as IUserInfoDAL;
        //}

        //public static IDepartmentDAL CreateDepartmentDAL()
        //{
        //    string fullNameSpace = AssNameSpace + ".DepartmentDAL";
        //    return CreateInstance(fullNameSpace) as IDepartmentDAL;
        //}
    }
}
